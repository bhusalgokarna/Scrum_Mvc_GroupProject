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
            var getAllDiscussie=_context.DiscussieThreads.Include(f=>f.forumCategory).Include(r=>r.Reacties).ToList();
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
        public IActionResult Search(string SearchString)
        {
            var getSearchString = _context.DiscussieThreads.Where(d => d.Comentaar.Contains(SearchString)).Include(f=>f.forumCategory);
            return View(getSearchString);
        }

        public IActionResult Reactie(int id)
        {
            var getAllreactie=_context.Reacties.Where(r=>r.DiscussieThreadId==id).Include(d=>d.discussieThread).ToList();
            return View(getAllreactie);
        }
    }
}
