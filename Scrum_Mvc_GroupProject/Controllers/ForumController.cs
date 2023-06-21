using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scrum_Mvc_GroupProject.Data;

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
        public IActionResult Create()
        {
            return View();
        }

        }
}
