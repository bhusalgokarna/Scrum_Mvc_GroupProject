using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scrum_Mvc_GroupProject.Data;
using Scrum_Mvc_GroupProject.Models;
using System.Threading;

namespace Scrum_Mvc_GroupProject.Controllers
{
    public class DiscussieThreadsController : Controller
    {
        private readonly ForumDbContext _context;
        public DiscussieThreadsController(ForumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var getAllDiscussie = _context.DiscussieThreads.Include(x => x.forumCategory).ToList();
            return View(getAllDiscussie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.forum = new SelectList(_context.ForumCategories.ToList(), "Id", "Naam");
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiscussieThread thread)
        {
            if (thread != null)
            {
                _context.DiscussieThreads.Add(thread);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var discussie = _context.DiscussieThreads.FirstOrDefault(c => c.Id == id);
            ViewBag.forum = new SelectList(_context.ForumCategories.ToList(), "Id", "Naam");
            return View(discussie);
        }
        [HttpPost]
        public IActionResult Edit(DiscussieThread discussie)
        {
            if (discussie != null)
            {
                _context.DiscussieThreads.Update(discussie);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var discussie = _context.DiscussieThreads.FirstOrDefault(c => c.Id == id);
            return View(discussie);
        }

        [HttpPost]
        public IActionResult Delete(DiscussieThread discussie)
        {
            _context.DiscussieThreads.Remove(discussie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DiscussiesLijst(int id)
        {
            var getAllDiscussie = _context.DiscussieThreads.Include(f => f.forumCategory).Where(i=>i.ForumCategoryId == id).ToList();
            return View(getAllDiscussie);
        }
    }
}
