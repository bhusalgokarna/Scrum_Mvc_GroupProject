using AspNetCore;
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
      
    }
}
