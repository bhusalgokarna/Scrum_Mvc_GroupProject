using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scrum_Mvc_GroupProject.Data;
using Scrum_Mvc_GroupProject.Models;

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
            var getAllDiscussie=_context.DiscussieThreads.Include(f=>f.forumCategory).ToList();
            return View(getAllDiscussie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.forum= new SelectList(_context.ForumCategories.ToList(), "Id", "Naam");
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
    }
}
