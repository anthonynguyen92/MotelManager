using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Motel.Application.Category.FamilyGroups;
using Motel.Application.Category.FamilyGroups.Dtos;
using System.Drawing;
using System.Threading.Tasks;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class FGroupController : ControllerBase
    {
        private readonly IManageFamily _manage;
        public FGroupController(IManageFamily family)
        {
            _manage = family;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]FamilyRequest request)
        {
            if (request != null)
            {
                var result = await _manage.Create(request);
                if (result == 0)
                    return BadRequest("??");
                return Ok("Success");
            }
            return BadRequest("Value is not null");
        }
     
        [HttpPut("Update")]
        public async Task<IActionResult> Update(string id,FamilyRequest request)
        {
            if (!string.IsNullOrEmpty(id) && request == null)
            {
                var result = await _manage.Update(id, request);
                if (result == 0)
                    return BadRequest("??");
                return Ok($"Add success {id}");
            }
            return BadRequest($"value cant empty");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = await _manage.Delete(id);
                if (result == 0)
                    return BadRequest($"?? {id}");
                return Ok($"Delete {id}");
            }
            return BadRequest($"Enter your id");
        }

        [HttpGet("id")]
        public IActionResult Find(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = _manage.Find(id);
                if (result == null)
                    return BadRequest($" your {id} are not exist");
                return Ok(result);
            }
            return BadRequest("Enter id??????");
        }

        [HttpPut("Update-name")]
        public async Task<IActionResult> UpdateName(string id,string fname,string lname)
        {
            if (!string.IsNullOrEmpty(id) &&  !string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname))
            {
                var reusult = await _manage.UpdateName(id, fname, lname);
                if (reusult == 0)
                    return BadRequest($"your {id} is not exist");
                return Ok($"Update Success");
            }
            return BadRequest($"Enter your id");
        }

        [HttpPut("Update-sex")]
        public async Task<IActionResult> UpdateSex(string id, string sex)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(sex))
            {
                var reusult = await _manage.UpdateSex(id, sex);
                if (reusult == 0)
                    return BadRequest($"your {id} is not exist");
                return Ok($"Update Success");
            }
            return BadRequest($"Enter your id");
        }

        [HttpPut("Update-Address")]
        public async Task<IActionResult> UpdateAddress(string id, string address)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(address))
            {
                var reusult = await _manage.UpdateAddress(id, address);
                if (reusult == 0)
                    return BadRequest($"your {id} is not exist");
                return Ok($"Update Success");
            }
            return BadRequest($"Value cant empty");
        }

        [HttpPut("Update-Identification")]
        public async Task<IActionResult> UpdateIdentification(string id,string idred)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(idred))
            {
                var reusult = await _manage.UpdateIdentification(id, idred);
                if (reusult == 0)
                    return BadRequest($"your {id} is not exist");
                return Ok($"Update Success");
            }
            return BadRequest($"Value cant null");
        }

        [HttpPut("Update-Phone")]
        public async Task<IActionResult> UpdatePhone(string id, string Phone)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(Phone))
            {
                var reusult = await _manage.UpdatePhoneNumber(id, Phone);
                if (reusult == 0)
                    return BadRequest($"your {id} is not exist");
                return Ok($"Update Success");
            }
            return BadRequest($"Enter your id");
        }
        
        [HttpGet("Get-Name")]
        public async Task<IActionResult> GetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _manage.GetByFirstName(name);
                if (result == null)
                    return BadRequest($"Dont have any {name}.");
                return Ok(result.Items);
            }
            return BadRequest($"Enter Name");
        }

        [HttpGet("Get-User")]
        public async Task<IActionResult>    GetUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = await _manage.GetByUserID(id);
                if (result == null) return BadRequest($"Dont have any {id}");
                return Ok(result.Items);
            }
            return BadRequest($"Enter your id");
        }

        [HttpPut("Update-id")]
        public async Task<IActionResult> UpdateIDUser(string id,string iduser)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(iduser))
            {
                var result = await _manage.UpdateUser(id, iduser);
                if (result == 0)
                    return BadRequest($" ?{id} ? {iduser}");
                return Ok($"Update your {id} successed");
            }
            return BadRequest($"Enter your id");
        }
    }
}
