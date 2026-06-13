using Identity_EF.Models;
using Identity_EF.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Identity_EF.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginAsync(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                var result = await
                    _signInManager.PasswordSignInAsync(loginVM.UserName!, loginVM.Password!, loginVM.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Login Invalid");
                return View(loginVM);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterVM
            {
                Roles = _roleManager.Roles
                .Select(x => new SelectListItem { Value = x.Name, Text = x.Name }).ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerVM.Name,
                    Email = registerVM.Email,
                    Direccion = registerVM.Direccion,
                    Nombres = registerVM.Nombres,
                };

                var result = await _userManager.CreateAsync(user, registerVM.Password!);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(registerVM.SelectedRole)
                        && await _roleManager.RoleExistsAsync(registerVM.SelectedRole))
                    {
                        await _userManager.AddToRoleAsync(user, registerVM.SelectedRole);
                    }
                }

                foreach(var error in  result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            registerVM.Roles = _roleManager.Roles.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            }).ToList();

            return View(registerVM);
        }
    }
}
