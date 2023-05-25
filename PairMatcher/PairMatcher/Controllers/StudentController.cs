using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using PairMatcher.DAL;
using PairMatcher.Helpers;
using PairMatcher.ViewModels;

namespace PairMatcher.Controllers
{
    // Content
    //
    // 1. Add Student
    // 2. Shuffle Students
    // 3. Delete Student


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
        [Authorize]

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

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

            return RedirectToAction("Students", "Student");
        }
        // =============================================
        // 1.  Students
        // =============================================

        public IActionResult Students()
        {
            var students = _context.Students.ToList();

            return View(students);
        }
        // =============================================
        // 2. Shuffle Students
        // =============================================
        [Authorize]
        public IActionResult Shuffle()
        {
            List<Student> students = _context.Students.ToList();

            students.ForEach(student => {
                student.PairStudent = null;
                student.PairStudentId = null;
                });


            PairingHelper.PairStudents(students);

            _context.SaveChanges();

            return RedirectToAction("index", "Home");
        }

        // =============================================
        // 3. Delete Student
        // =============================================
        [Authorize]

        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            var pair = _context.Students.FirstOrDefault(x => x.PairStudentId == id);
            if (pair != null)
            {
                pair.PairStudentId = null;
                pair.PairStudent = null;
            }


            _context.SaveChanges();
            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok();
        }

    }
}
