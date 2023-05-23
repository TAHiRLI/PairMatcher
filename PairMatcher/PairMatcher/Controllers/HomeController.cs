using Microsoft.AspNetCore.Mvc;
using PairMatcher.DAL;
using PairMatcher.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PairMatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly PairMatcherDbContext _context;

        public HomeController(PairMatcherDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();

            return View(students);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}