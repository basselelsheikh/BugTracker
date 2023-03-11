using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.UI.DTO.AccountDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Route("/")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            //email and password model validation
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }
            //trying to sign in
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(HomeController.Index), "Index");
            }
            //In case of wrong credentials, show the sign-in view again with that error
            else
            {
                ModelState.AddModelError("Login", "Invalid email or password");
                return View(loginDTO);
            }


        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationUser user = new ApplicationUser() { Email = model.Email, PhoneNumber = model.PhoneNumber, UserName = model.Email, Name = model.FirstName + " " + model.LastName};
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //Sign in
                await _signInManager.SignInAsync(user, isPersistent: true);

                //NOTE: add team views
                return RedirectToAction(nameof(PersonsController.Index), "Persons");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Registration Error", error.Description);
                }

                return View(model);
            }
        }
    }
}
