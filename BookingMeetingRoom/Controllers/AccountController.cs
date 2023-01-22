using BookingMeetingRoom.Models;
using BookingMeetingRoom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingMeetingRoom.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
                    , RoleManager<IdentityRole> roleManager
                    , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel data)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = data.UserName;
                user.Email = data.Email;
                user.FullName = data.FullName;
                user.Position = data.Position;
                user.Department = data.Department;
                user.TelNumber = data.TelNumber;
                user.ImageName = data.ImageName;

                var result = await _userManager.CreateAsync(user, data.Password);

                if (result.Succeeded)
                {
                    //if (!await _roleManager.RoleExistsAsync("Member"))
                    //{
                    //    var role = new IdentityRole("Member");
                    //    var roleResult = await _roleManager.CreateAsync(role);
                    //}
                    //
                    await _userManager.AddToRoleAsync(user, "Admin");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View("Index", data);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(data.UserName, data.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Fail");
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}
