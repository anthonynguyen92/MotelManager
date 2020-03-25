using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motel.Application.Category.BillPayment;
using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.Entities;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillPaymentController : ControllerBase
    {
        private readonly IManageBillPayment _manage;
        private IPublicBillPayment _publicpayment;

        public BillPaymentController(IManageBillPayment manage, IPublicBillPayment publicpayment)
        {
            _manage = manage;
            _publicpayment = publicpayment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // localhost:port/api​/BillPayment​/deletebill
        [HttpDelete("deletebill")]
        public async Task<IActionResult> Get([FromBody]BillPaymentDelete delete)
        {
            var result = await _manage.Delete(delete);
            if (result == 0)
                return NotFound();
            return Ok();
        }

        // CREATE - dont have modelisvalid
        [HttpPost("create-billpayment")]
        public async Task<IActionResult> Create([FromBody]BillPaymentCreate create)
        {
           var result = await _manage.Create(create);
            if (result == 0)
                return BadRequest();
            return Ok("create ok");
        }

        // PUT - update add bill 
        [HttpPut("update-allbillpayment")]
        public async Task<IActionResult> Update(BillPaymentUpdate infor)
        {
            var result = await _manage.Update(infor);
            if (result == 0)
                return NotFound();
            return Ok("updated");
        }

        // GET True idbill when u enter true id
        [HttpGet("Find-by-id")]
        public async Task<IActionResult> Find(string find)
        {
            var result = await _manage.Find(find);
            if (result == null)
                return BadRequest("cant find bill");
            return Ok(result);
        }

        // PUT - Update Month Rent
        [HttpPut("Update-MonthRent")]
        public async Task<IActionResult> UpdateMoth([FromBody]string id,int month)
        {
            var result = await _manage.UpdateMontRent(id, month);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }

        // PUT - Update Water Bill
        [HttpPut("Update-WaterBill")]
        public async Task<IActionResult> UpdateWaterBill(String id, decimal price)
        {
            var result = await _manage.UpdateWaterBill(id, price);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }

        // PUT - Update Enectric Bill
        [HttpPut("Update-ElectricBill")]
        public async Task<IActionResult> UpdateElectricBill(String id, decimal price)
        {
            var result = await _manage.UpdateElectricBill(id, price);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }

        // PUT - Update Wifi Bill
        [HttpPut("Update-WifiBill")]
        public async Task<IActionResult> UpdateWifiBill(String id, decimal price)
        {
            var result = await _manage.UpdateWifiBill(id, price);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }

        // PUT - Update Parking Fee
        [HttpPut("Update-ParkingFee")]
        public async Task<IActionResult> UpdateParkingFee(String id, decimal price)
        {
            var result = await _manage.UpdateParkingFee(id, price);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }

        // PUT - Update Room Bill
        [HttpPut("Update-RoomBill")]
        public async Task<IActionResult> UpdateRoomBill(String id, decimal price)
        {
            var result = await _manage.UpdateRoomBil(id, price);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }

        // PUT - Update IDMotel
        [HttpPut("Update-IdMotels")]
        public async Task<IActionResult> UpdateMotelRoom(String id, int price)
        {
            var result = await _manage.UpdateIdMotel(id, price);
            if (result == 0)
                return BadRequest("dont exists");
            return Ok(result);
        }
    }
}