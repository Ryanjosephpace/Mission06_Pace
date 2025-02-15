using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Pace.Models;

namespace Mission06_Pace.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FillOutApplication()
        {
            return View("MovieApplication");
        }

        [HttpPost]
        public IActionResult MovieApplication(Review response)
        {
            _context.Reviews.Add(response);
            _context.SaveChanges();

  

            return View("Index", response);
        }

        public IActionResult MeetJoel()
        {
            return View("AboutJoel");
        }
    }
}