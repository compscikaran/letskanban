using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using letskanban.Models;
using letskanban.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace letskanban.Controllers 
{
    [Authorize]
    public class StoryController : Controller
    {
        private ApplicationDbContext _context;
        public StoryController()
        {
            _context = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            var statusTypes = _context.Stories.ToList();
            return View(statusTypes);
        }

        public IActionResult New()
        {
            var users = _context.Users.Select(m => m.UserName).ToList();
            ViewBag.users = users;
            return View();
        }

        [HttpPost]
        public IActionResult CreateStory(Story story)
        {
            story.Status = Types.Todo;
            if (ModelState.IsValid)
            {
                _context.Stories.Add(story);
                _context.SaveChanges();
            }
            else
            {
                return View("New");
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditStory(int Id)
        {
            var users = _context.Users.Select(m => m.UserName).ToList();
            ViewBag.users = users;
            var story = _context.Stories.First(m => m.Id == Id);
            if (story == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(story);
            }

        }
        [HttpPost]
        public IActionResult EditStory(int Id, EditViewModel model)
        {
            var story = _context.Stories.FirstOrDefault(m => m.Id == Id);
            if (ModelState.IsValid)
            {
                story.Name = model.Name;
                story.ModuleName = model.ModuleName;
                story.Description = model.Description;
                story.UserName = model.UserName;
                story.DueDate = model.DueDate;
                story.HoursRequired = model.HoursRequired;
                story.Priority = model.Priority;
                _context.SaveChanges();
                return RedirectToAction("Index", "Story");

            }
            else
            {
                return View(story);
            }

        }

        public IActionResult TransferToDoing(int Id)
        {
            var story = _context.Stories.FirstOrDefault(m => m.Id == Id);
            story.Status = Types.Doing;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult TransferToDone(int Id)
        {
            var story = _context.Stories.FirstOrDefault(m => m.Id == Id);
            story.Status = Types.Done;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult TransferToDo(int Id)
        {
            var story = _context.Stories.FirstOrDefault(m => m.Id == Id);
            story.Status = Types.Todo;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ClearDoneStories()
        {
            var doneStories = _context.Stories.Where(m => m.Status == Types.Done);
            foreach (var story in doneStories)
            {
                _context.Stories.Remove(story);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SendReminders()
        {
            var storiesDue = _context.Stories.Where(m => m.DueDate == DateTime.Now.Date).ToList();
            if (storiesDue.Count != 0)
            {
                foreach (var story in storiesDue)
                {
                    var mailer = new Mailer(story);
                    mailer.SendStoryReminder();
                }
            }
            return RedirectToAction("Index");
        }
    } 
}
