using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Pace.Models;
using static System.Net.Mime.MediaTypeNames;

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
            ViewBag.Categories = _context.Categories.ToList();
            return View("MovieApplication", new Movies());
        }

        [HttpPost]
        public IActionResult MovieApplication(Movies response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Index", response);
        }

        public IActionResult MeetJoel()
        {
            return View("AboutJoel");
        }

        public IActionResult List()
        {
            //Linq
            var applications = _context.Movies
                .Include(m => m.Category)
                .OrderBy(x => x.Title).ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("list");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .SingleOrDefault(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieApplication", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            Console.WriteLine($"Received Movie ID: {updatedInfo.MovieId}");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
                return View("MovieApplication", updatedInfo);
            }

            _context.Entry(updatedInfo).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("List");
        }



    }
}