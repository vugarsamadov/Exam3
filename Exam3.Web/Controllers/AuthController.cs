using System.Security.Permissions;
using Exam3.Business.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Exam3.Web.Controllers
{
    public class AuthController : Controller
    {

        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public SignInManager<IdentityUser> _signInManager { get; }
        private UserManager<IdentityUser> _userManager { get; }
        private RoleManager<IdentityRole> _roleManager { get; }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is wrong!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is wrong!");
                return View(model);
            }

            return RedirectToAction("Index","Admin");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser() {UserName=model.Email,Email=model.Email};

            var result = await _userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

    }
}
