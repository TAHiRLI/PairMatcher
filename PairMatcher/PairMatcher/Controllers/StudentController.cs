using Microsoft.AspNetCore.Mvc;

namespace PairMatcher.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
