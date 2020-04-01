using Microsoft.AspNetCore.Mvc;
using Motel.Application.Category.InfoRent;
using Motel.Application.Category.InfoRent.Dtos;

using System;
using System.Threading.Tasks;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentMController : ControllerBase
    {
        private readonly IManageRent _rent;
        public RentMController(IManageRent rent)
        {
            _rent = rent;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string id, string customer, int motel)
        {
            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(customer))
                return BadRequest("???");

            var result = await _rent.Create(id, customer, motel);

            if (result == 0)
                return BadRequest("???");
            return Ok($"Create {id} Successed");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("????");

            var result = await _rent.Delete(id);
            if (result == 0)
                return BadRequest("????");
            return Ok("Delete Success");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(RentRequest request, string id)
        {
            if (request == null || string.IsNullOrEmpty(id))
                return BadRequest("??");

            var result = await _rent.Update(request, id);
            if (result == 0)
                return BadRequest("??");
            return Ok($"Update {id} successed");
        }

        // fix date = null but -> return ok
        [HttpPut("Update-Start")]
        public async Task<IActionResult> UpdateDate(string id, DateTime date)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("???");
            if(date==null)
                return BadRequest("????");
            var result = await _rent.UpdateDate(id, date);
            if (result == 0)
                return BadRequest($"Xin chao day la 1 stupid do ban sinh ra !!");
            return Ok($"ok co to chat");
        }

        [HttpPut("Update-End")]
        public async Task<IActionResult> UpdateDateEnd(string id, DateTime date)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest($"Xin chao day la 1 stupid do ban sinh ra !!");
            if(date == null)
                return BadRequest($"Xin chao day la 1 stupid do ban sinh ra !!");

            var result = await _rent.UpdateDateEnd(id, date);
            if (result == 0)
                return BadRequest($"Xin chao day la 1 stupid do ban sinh ra !!");
            return Ok($"ok co to chat");
        }

        [HttpPut("Update-IdMotel")]
        public async Task<IActionResult> UpdateIdMotel(string id, int idmotel)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("??");
            var result = await _rent.UpdateIdMotel(id, idmotel);
            if (result == 0)
                return BadRequest($"Xin chao day la 1 stupid do ban sinh ra !!");
            return Ok($"ok co to chat");
        }

        [HttpPut("Update-User")]
        public async Task<IActionResult> UpdateIdMotel(string id, string user)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(user))
                return BadRequest("??");
            var result = await _rent.UpdateIdCustomer(id, user);
            if (result == 0)
                return BadRequest($"Xin chao day la 1 stupid do ban sinh ra !!");
            return Ok($"ok co to chat");
        }

        [HttpGet("Get-Id")]
        public IActionResult GetID(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Please Enter your id");
            var result = _rent.GetById(id);
            if (result == null)
                return BadRequest("???");
            return Ok(result);
        }

        // return a string  -> iduser 
        [HttpGet("ID-Model")]
        public async Task<IActionResult> getByMotel(int id)
        {
            if (id < 0)
                return BadRequest("??");
            var result = await _rent.GetByIDMotel(id);
            if (string.IsNullOrEmpty(result))
                return BadRequest("No string!!");
            return Ok($"Your id user: {result}");
        }

        // return a int -> idmotel
        [HttpGet("ID-User")]
        public async Task<IActionResult> getbyUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Enter your id");
            var result = await _rent.GetByIdUser(id);
            if (result <= 0)
                return BadRequest("??");
            return Ok($"Your {id} is {result}");
        }

        [HttpGet("Get-End")]
        public async Task<IActionResult> getEndDay()
        {
            var result = await _rent.GetByEndDate();
            if (result == null)
                return Ok("No any one");
            return Ok(result.Items);
        }

        [HttpGet("User")]
        public async Task<IActionResult> getUser(string iduser)
        {
            if (string.IsNullOrEmpty(iduser))
                return BadRequest("Enter your id");
            var result = await _rent.GetRoom(iduser);
            if (result == null)
                return BadRequest("No anyone");
            return Ok(result.Items);

        }

        [HttpGet("Room")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var result = await _rent.GetRoom(id);
            if (result == null)
                return BadRequest("??");
            return Ok(result.Items);
        }
    }
}
