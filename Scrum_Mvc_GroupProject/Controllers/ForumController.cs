using Microsoft.AspNetCore.Mvc;
using Scrum_Mvc_GroupProject.Data;
using Scrum_Mvc_GroupProject.Models;

namespace Scrum_Mvc_GroupProject.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumDbContext _context;
        public ForumController(ForumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var getCategories = _context.ForumCategories.ToList();
            return View(getCategories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ForumCategory forum)
        {
            if (forum!=null)
            {
                _context.ForumCategories.Add(forum);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
          
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.ForumCategories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(ForumCategory category)
        {
            _context.ForumCategories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
