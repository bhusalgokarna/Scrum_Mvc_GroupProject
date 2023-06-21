using Microsoft.AspNetCore.Mvc;

namespace Scrum_Mvc_GroupProject.Controllers
{
    public class DiscussieThreadsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
