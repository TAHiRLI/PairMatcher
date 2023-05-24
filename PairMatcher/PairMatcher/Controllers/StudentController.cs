using Microsoft.AspNetCore.Mvc;
using PairMatcher.DAL;
using PairMatcher.ViewModels;

namespace PairMatcher.Controllers
{
    // Content
    //
    // 1. Add Student

    public class StudentController : Controller
    {
        private readonly PairMatcherDbContext _context;

        public StudentController(PairMatcherDbContext context)
        {
            _context = context;
        }

        // =============================================
        // 1. Add Student
        // =============================================

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentAddVM studentVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Student student = new Student()
            {
                Name = studentVM.Name,
                Gender = studentVM.Gender,
                SameGenderMatch = studentVM.SameGenderMatch,
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Students","Student");
        }
        // =============================================
        // 1.  Students
        // =============================================

        public IActionResult Students()
        {
            var students = _context.Students.ToList() ;

            return View(students);
        }

    }
}
