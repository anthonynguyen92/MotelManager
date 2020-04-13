using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motel.Application.Category.User;
using Motel.CustomerAuth;
using Motel.Models;
using System.Threading.Tasks;

namespace Motel.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login() => View();

        // fix here ??/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            //if (!ModelState.IsValid)
            //    return Redirect("~/Index");

            var token = await _service.Authentication(user.username, user.password);
            if (!string.IsNullOrEmpty(token))
            {
                HttpContext.Session.SetString("JWToken", token);
                // return manager
                return RedirectToAction("Index", "Manage");
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }

        public IActionResult Index() => View();

        public IActionResult Logoff()
        {
            foreach(var cookie in Request.Cookies.Keys)
            {
                HttpContext.Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login","Account");
        }
    }
}
