using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using letskanban.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace letskanban.Controllers
{
    public class FileController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;
        private ApplicationDbContext _context;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = new ApplicationDbContext();
        }
        public IActionResult Index()
        {
            var files = _context.Files.ToList();
            return View(files);
        }
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                var _file = new DocFile();
                _file.Title = file.FileName;
                _file.FilePath = filePath;
                if (ModelState.IsValid)
                {
                    _context.Files.Add(_file);
                    _context.SaveChanges();
                }
                else
                {
                    return View("Upload");
                }
            }
                return RedirectToAction("Index");
            }
        
    }
}
