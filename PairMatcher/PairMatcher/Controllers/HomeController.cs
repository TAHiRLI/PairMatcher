using Microsoft.AspNetCore.Mvc;
using PairMatcher.DAL;
using PairMatcher.Helpers;
using PairMatcher.Models;
using PairMatcher.ViewModels;
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

            PairingHelper.PairStudents(students);

            HomeVM homeVM = new HomeVM();

            homeVM.Students = students.OrderBy(student=>student.Name).ToList();
            return View(homeVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}