using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PairMatcher.DAL;
using PairMatcher.Models;
using PairMatcher.ViewModels;

namespace PairMatcher.Controllers
{

    // Content 
    //
    // 1. Login get/post

    public class AccountController : Controller
    {
        private readonly PairMatcherDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(PairMatcherDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // =============================================
        // 1. Login get/post
        // =============================================
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Istifadəçi adı və ya şifrə yanlışdır");
                return View();

            }

           var result =  await _signInManager.PasswordSignInAsync(user,loginVM.Password,true,false);
            

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Istifadəçi adı və ya şifrə yanlışdır");
                return View();

            }
            return RedirectToAction("index", "Home");

        }

        // =============================================
        // 2. Logout
        // =============================================

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        // =============================================
        // Create admin
        // =============================================
        //public async Task<IActionResult>  CreateAdmin()
        //{
        //    AppUser admin = new AppUser();
        //    AppUser aziza = new AppUser();

        //    aziza.UserName = "TahirliAziza";
        //    admin.UserName = "Admin";


        //    var result =await _userManager.CreateAsync(admin, "admin2023");
        //    var azizaResult = await _userManager.CreateAsync(aziza, "aziza2002");

        //    if (!result.Succeeded  )
        //    {
        //        return Ok(result.Errors);
        //    }
        //    if (!azizaResult.Succeeded)
        //    {
        //        return Ok(azizaResult.Errors);
        //    }


        //    return Ok();
        //}
    }
}
