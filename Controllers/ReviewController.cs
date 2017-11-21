using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using letskanban.Models;
using Microsoft.AspNetCore.Mvc;

namespace letskanban.Controllers {
    public class ReviewController : Controller
    {
        private ApplicationDbContext _context;
        private int _reviewId;
        public ReviewController() 
        {
            _context = new ApplicationDbContext();
            _reviewId = 0;
        }
        public IActionResult Index()
        {
            var reviews = _context.Reviews.ToList();
            return View(reviews);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            if(ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
            }
            else
            {
                return View("New");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int Id)
        {
            var review = _context.Reviews.FirstOrDefault(m => m.Id == Id);
            var comments = _context.Comments.Where(m => m.CodeId == Id).ToList();
            ViewBag.comments = comments;
            return View(review);
        }
        public IActionResult AddComment(int Id)
        {
            var comment = new Comment();
            comment.CodeId = Id;
            return View(comment);
        }
      
        [HttpPost]
        public IActionResult SaveComment(Comment comment)
        {
            System.Console.WriteLine(comment.CodeId);
            if(ModelState.IsValid)
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            else
            {
                return View("AddComment",comment);
            }
            return RedirectToAction("Detail",new {id = comment.CodeId});
        }
    }
}