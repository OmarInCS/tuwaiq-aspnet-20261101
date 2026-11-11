using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "APP_ADMIN")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "APP_ADMIN")]
        public async Task<ActionResult> Create(UserCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);    
            }
            
            var user = new IdentityUser
            {
                Email = vm.Email,
                UserName = vm.Email,
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Email", "Failed to create user, maybe email already exists");
                return View(vm);
            }

            result = await _userManager.AddToRoleAsync(user, vm.Role.ToString());
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Email", "Failed add role to the user");
                return View(vm);
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
