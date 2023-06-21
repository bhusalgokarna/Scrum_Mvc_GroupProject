
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scrum_Mvc_GroupProject.Data;
using Scrum_Mvc_GroupProject.Models;

namespace Scrum_Mvc_GroupProject.Controllers
{
    public class ReactiesController : Controller
    {
        private readonly ForumDbContext _context;
        public ReactiesController(ForumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var getAllReatie=_context.Reacties.Include(d=>d.discussieThread).ToList();
            return View(getAllReatie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.discussie = new SelectList(_context.DiscussieThreads.ToList(), "Id", "Comentaar");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reactie reactie)
        {
            if (reactie != null) 
            { 
                _context.Reacties.Add(reactie);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reactie = _context.Reacties.FirstOrDefault(c => c.Id == id);
            ViewBag.discussie = new SelectList(_context.DiscussieThreads.ToList(), "Id", "Comentaar");
            return View(reactie);
        }
        [HttpPost]
        public IActionResult Edit(Reactie reactie)
        {
            if (reactie != null)
            {
                _context.Reacties.Update(reactie);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var reactie = _context.Reacties.FirstOrDefault(c => c.Id == id);
            //ViewBag.discussie = new SelectList(_context.DiscussieThreads.ToList(), "Id", "Comentaar");
            return View(reactie);
        }
        [HttpPost]
        public IActionResult Delete(Reactie reactie)
        {
            _context.Reacties.Remove(reactie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
