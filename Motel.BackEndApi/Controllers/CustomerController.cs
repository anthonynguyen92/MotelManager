using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motel.Application.Category.CustomerRent;
using Motel.Application.Category.CustomerRent.Dtos;
using System.Threading.Tasks;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IManageCustomer _customer;

        public CustomerController(IManageCustomer customer)
        {
            _customer = customer;
        }

        [HttpGet("Test")]
        public IActionResult Get() => Ok();

        [HttpPost("Create-Customer")]
        public async Task<IActionResult> Create(CustomerRequest request)
        {
            var result = await _customer.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(request);
        }

        [HttpDelete("Delete-Customer")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _customer.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-Customer")]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest request)
        {
            var result = await _customer.Update(request.IDuser, request);
            if (result == 0)
                return BadRequest();
            return Ok(result);

        }

        [HttpGet("Get-Customer")]
        public IActionResult GetCustomer(string id)
        {
            var result = _customer.Find(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-address")]
        public async Task<IActionResult> UpdateAddress(string id, string address)
        {
            var result = await _customer.UpdateAddress(id, address);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-Email")]
        public async Task<IActionResult> UpdateEmail(string id, string email)
        {
            var result = await _customer.UpdateEmail(id, email);
            if (result != 1)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-Identification")]
        public async Task<IActionResult> UpdateIdentification(string id, string identification)
        {
            var result = await _customer.UpdateIdentification(id, identification);
            if (result != 1)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-Name")]
        public async Task<IActionResult> UpdateName(string id, string fname, string lname)
        {
            var result = await _customer.UpdateName(id, fname, lname);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-PhoneNumber")]
        public async Task<IActionResult> UpdatePhoneNumber(string id, string Phone)
        {
            var result = await _customer.UpdatePhoneNumber(id, Phone);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-Sex")]
        public async Task<IActionResult> UpdateSex(string id, string sex)
        {
            var result = await _customer.UpdateSex(id, sex);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }

        //Summarry
        // 
        // first if u wanna return a number of list -> return record.
        // 
        // second if u wanna return a list of customer -> return item.
        //
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customer.GettAll();
            return Ok(result.Items);
        }

        [HttpGet("Get-Name")]
        public async Task<IActionResult> GetListByName(string name)
        {
            var request = await _customer.GetByFirstName(name);
            if (request == null)
                return NotFound();
            return Ok(request.Items);
        }

        [HttpGet("Get-id")]
        public IActionResult getID(CustomerRequest request) => Ok(request.IDuser);
        /*
         * update - modelivalid - 
         * update get value by pagination
         */
    }
}
