using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillPaymentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Test Ok");
        }
    }
}