using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using Motel.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Motel.Application.Category.BillPayment
{
    public class ManageBillPayment : IManageBillPayment
    {
        private readonly MotelDbContext _context;
        public ManageBillPayment(MotelDbContext context)
        {
            _context = context;
        }


        /*
         * id is a value of motel room and u must get id for it
         */
        // POST: create a bill payment
        public async Task<int> Create(BillPaymentCreate create, int id)
        {
            var bill = new InforBill()
            {
                ElectricBill = create.ElectricBill,
                IdInforBill = create.Id,
                MonthRent = create.MonthRent,
                ParkingFee = create.ParkingFee,
                RoomBill = create.RoomBil,
                WaterBill = create.WaterBill,
                WifiBill = create.WifiBill,
                IdMotel = id,
            };
            _context.InforBills.Add(bill);
            return await _context.SaveChangesAsync();
        }


        // DELETE: delete a bill payment
        public async Task<int> Delete(BillPaymentDelete delete)
        {
            var bill = _context.InforBills.Find(delete.IDFind);
            if (bill == null) throw new MotelExceptions($"Cant find bill {delete.IDFind} ");
            _context.InforBills.Remove(bill);
            return await _context.SaveChangesAsync();
        }

        // GET Update - have more and more infor so u need add s.th func, example : update money ....
        public async Task<int> Update(BillPaymentUpdate update)
        {
            // fix exception 
            var bill = _context.InforBills.Find(update.Id);
            if (bill == null) throw new MotelExceptions($"Cant find bill id {update.Id} please enter id correct");
            else
            {
                var billupdate = new InforBill()
                {
                    ElectricBill = update.ElectricBill,
                    IdInforBill = update.Id,
                    // fix idmotel
                    MonthRent = update.MonthRent,
                    ParkingFee = update.ParkingFee,
                    RoomBill = update.RoomBil,
                    WaterBill = update.WaterBill,
                    WifiBill = update.WifiBill,
                };
                _context.InforBills.Update(billupdate);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BillPaymentViewModel>> GetAll()
        {

            throw new NotImplementedException();
        }

        //GET seach with kw
        // it's need to fix and uncheck. 
        public async Task<PagedViewModel<BillPaymentViewModel>> GetAllPaging(GetBillPaymentRequest request)
        {
            //1. Select join
            var query = from c in _context.InforBills
                        join mr in _context.MotelRooms on c.IdMotel equals mr.idMotel
                        select new { c, mr };
            
            //2.Filter
            if (!String.IsNullOrEmpty(request.kw))
                query = query.Where(x => x.mr.NameRoom.Contains(request.kw));
            if(request.Categoryid.Count() >0)
            {
                //????
            }

            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PIndex - 1) * request.PSize)
                .Take(request.PSize)
                .Select(x=> new BillPaymentViewModel()
                {
                    Id = x.c.IdInforBill,
                    ElectricBill = x.c.ElectricBill,
                    MonthRent =x.c.MonthRent,
                    ParkingFee = x.c.ParkingFee,
                    RoomBil = x.c.RoomBill,
                    WaterBill = x.c.WaterBill,
                    WifiBill = x.c.WifiBill
                }).ToListAsync();

            //4. select and projection 
            var pageResult = new PagedViewModel<BillPaymentViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;
        }

        public Task<int> Create(BillPaymentCreate create)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMotelRoomList()
        {
            var query = from c in _context.MotelRooms
                        orderby c.idMotel
                        select c.idMotel;
            return query.ToList();
        }
    }
}
