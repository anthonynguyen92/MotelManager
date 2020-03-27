using Microsoft.AspNetCore.Mvc;
using Motel.Application.Category.RoomMotel;
using Motel.Application.Category.RoomMotel.Dtos;
using Motel.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RoomMotelController : ControllerBase
    {
        private readonly IManageRoomMotel _manage;

        public RoomMotelController( IManageRoomMotel manage)
        {
            _manage = manage;
        }

        [HttpGet("Test")]
        public IActionResult Test() => Ok();
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create(RoomRequest request)
        {
            var result = await _manage.Create(request);
            if (request == null)
                return Ok("bad");
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var result = _manage.Find(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("Update-all")]
        public async Task<IActionResult> Update(RoomRequest request)
        {
            var result = await _manage.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        
        [HttpPut("Update-Name")]
        public async Task<IActionResult> UpdateName(int id ,string name)
        {
            var result = await _manage.UpdateName(id, name);
            if (result == 0)
                throw new MotelExceptions("bad request");
            return Ok("success");
        }

        [HttpPut("Update-Payment")]
        public async Task<IActionResult> UpdatePayment(int id,decimal price)
        {
            var result = await _manage.UpdatePayment(id, price);
            if (result == 0)
                throw new MotelExceptions("bad reques");
            return Ok("SUccess");
        }

        [HttpPut("Update-Status")]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            var result = await _manage.UpdateStatus(id);
            if (result == 0)
                throw new MotelExceptions("bad reques");
            return Ok("SUccess");
        }

        [HttpPut("Update-Infor")]
        public async Task<IActionResult> UpdateInfor(int id, int bedroom,int toilet) 
        {
            var result = await _manage.UpdateInfor(id, bedroom,toilet);
            if (result == 0)
                throw new MotelExceptions("bad reques");
            return Ok("SUccess");
        }

        [HttpPut("Update-Area")]
        public async Task<IActionResult> UpdateArea(int id, int square)
        {
            var result = await _manage.UpdateArea(id, square);
            if (result == 0)
                throw new MotelExceptions("bad reques");
            return Ok("SUccess");
        }

        [HttpGet("Get-List")]
        public async Task<IActionResult> Getall()
        {
            var result = await _manage.GetAll();
            return Ok(result.Items);
        }

        [HttpGet("Empty")]
        public async Task<IActionResult> GetEmpty()
        {
            var result = await _manage.GetEmptyRoomAsync();
            return Ok(result.Items);
        }

        [HttpGet("Get-name")]
        public async Task<IActionResult> GetName(string Name)
        {
            var result = await _manage.GetRoomByName(Name);
            return Ok(result.Items);
        }

    }
}
