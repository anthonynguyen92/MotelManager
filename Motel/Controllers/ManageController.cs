using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Motel.Controllers
{
    public class ManageController : Controller
    {
        [Authorize]
        public IActionResult Index() => View();
    }
}
