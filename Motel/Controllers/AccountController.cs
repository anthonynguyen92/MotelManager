using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Motel.Data;
using Motel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDBcontext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDBcontext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //LOGIN
        public ViewResult Login() => View();
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Wrong usename or password");
            }
            return View(nameof(Index));
        }


        // REGISTER
        public ViewResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(String name, string password,String firstname,string lastname)
        {
            var user = new ApplicationUser
            {
                UserName = name,
                FirstName = firstname,
                LastName = lastname
            };
            var reg = await _userManager.CreateAsync(user, password);
            if (reg.Succeeded && ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                    return RedirectToAction("SignIn");
                else
                    foreach (IdentityError error in reg.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(nameof(Register));
        }
    }
}
