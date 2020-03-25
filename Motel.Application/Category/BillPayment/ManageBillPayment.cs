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
        public async Task<int> Create(BillPaymentRequest create, int id)
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
        public async Task<int> Delete(BillPaymentRequest delete)
        {
            var bill = _context.InforBills.Find(delete.IDFind);
            if (bill == null) throw new MotelExceptions($"Cant find bill {delete.IDFind} ");
            else _context.InforBills.Remove(bill);
            return await _context.SaveChangesAsync();
        }

        // GET Update - have more and more infor so u need add s.th func, example : update money ....
        public async Task<int> Update(BillPaymentRequest update)
        {
            // fix exception 
            var bill = _context.InforBills.Find(update.Id);
            if (bill == null) throw new MotelExceptions($"Cant find bill id {update.Id} please enter id correct");
            else
            {
                if (!GetMotelRoomList().Contains(update.IdMotel))
                    throw new MotelExceptions($" {update.IdMotel} cant match or dont exists {update.IdMotel} in database");
                else
                {
                    bill.IdInforBill = update.Id;
                    bill.ElectricBill = update.ElectricBill;
                    bill.IdMotel = update.IdMotel;
                    bill.MonthRent = update.MonthRent;
                    bill.ParkingFee = update.ParkingFee;
                    bill.RoomBill = update.ParkingFee;
                    bill.WaterBill = update.WaterBill;
                    bill.WifiBill = update.WifiBill;
                    _context.InforBills.Update(bill);

                }
            }
            return await _context.SaveChangesAsync();
        }

        // GET get all bill payment (not have lazy loading
        public async Task<PagedViewModel<BillPaymentRequest>> GetAllBillpayment()
        {
            var kq = from v in _context.InforBills
                     orderby v.IdInforBill
                     select v;
            var answ = kq.Count();
            var data = await kq.Select(x => new BillPaymentViewModel
            {
                Id = x.IdInforBill,
                ElectricBill = x.ElectricBill,
                MonthRent = x.MonthRent,
                ParkingFee = x.ParkingFee,
                RoomBil = x.RoomBill,
                WaterBill = x.WaterBill,
                WifiBill = x.WifiBill,
                IdMotel = x.IdMotel
            }).ToListAsync();

            var result = new PagedViewModel<BillPaymentViewModel>()
            {
                Items = data,
                TotalRecord = kq.Count(),
            };
            return result;

        }

        //GET fix!!!!
        public Task<PagedViewModel<BillPaymentRequest>> GetAllPaging(BillPaymentRequest request)
        {
            #region need fix all
            ////1. Select join
            //var query = from c in _context.InforBills
            //            join mr in _context.MotelRooms on c.IdMotel equals mr.idMotel
            //            select new { c, mr };

            ////2.Filter
            //if (!String.IsNullOrEmpty(request.kw))
            //    query = query.Where(x => x.mr.NameRoom.Contains(request.kw));

            ////3.Paging
            //int totalRow = await query.CountAsync();
            //var data = await query.Skip((request.PIndex - 1) * request.PSize)
            //    .Take(request.PSize)
            //    .Select(x => new BillPaymentRequest()
            //    {
            //        Id = x.c.IdInforBill,
            //        ElectricBill = x.c.ElectricBill,
            //        MonthRent = x.c.MonthRent,
            //        ParkingFee = x.c.ParkingFee,
            //        RoomBil = x.c.RoomBill,
            //        WaterBill = x.c.WaterBill,
            //        WifiBill = x.c.WifiBill
            //    }).ToListAsync();

            ////4. select and projection 
            //var pageResult = new PagedViewModel<BillPaymentViewModel>()
            //{
            //    TotalRecord = totalRow,
            //    Items = data
            //};
            //return pageResult;
            #endregion
            throw new NotImplementedException();
        }

        // POST Create a bill payment
        public async Task<int> Create(BillPaymentRequest create)
        {
            var billcreate = new InforBill()
            {
                IdInforBill = create.Id,
                ElectricBill = create.ElectricBill,
                IdMotel = create.IdMotel,
                MonthRent = create.MonthRent,
                ParkingFee = create.ParkingFee,
                RoomBill = create.RoomBil,
                WaterBill = create.WaterBill,
                WifiBill = create.WifiBill,
            };
            if (GetMotelRoomList().Contains(billcreate.IdMotel))
                _context.InforBills.Add(billcreate);
            else
                throw new MotelExceptions($"{billcreate.IdMotel} cant match or dont exists {billcreate.IdMotel} in database");
            return await _context.SaveChangesAsync();
        }

        public List<int> GetMotelRoomList()
        {
            var query = from c in _context.MotelRooms
                        select c.idMotel;
            return query.ToList();
        }

        // GET Find an id bill - enter true id and it's will return if not => null
        public async Task<BillPaymentRequest> Find(string id)
        {
            var result = await _context.InforBills.FindAsync(id);
            if (result == null || string.IsNullOrEmpty(id))
                return null;
            BillPaymentRequest value = new BillPaymentRequest()
            {
                ElectricBill = result.ElectricBill,
                Id = result.IdInforBill,
                IdMotel = result.IdMotel,
                MonthRent = result.MonthRent,
                ParkingFee = result.ParkingFee,
                RoomBil = result.RoomBill,
                WaterBill = result.WaterBill,
                WifiBill = result.WifiBill,
            };
            return value;
        }
        //Update detail of Bill - Month
        public async Task<int> UpdateMonthRent(string id, int price)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.MonthRent = price;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();

        }
        
        //Update detail of Bill - Water
        public async Task<int> UpdateWaterBill(string id, decimal price)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.WaterBill = price;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
       
        //Update detail of Bill - Electric
        public async Task<int> UpdateElectricBill(string id, decimal price)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.ElectricBill = price;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
        
        //Update detail of Bill - Wifi
        public async Task<int> UpdateWifiBill(string id, decimal price)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.WifiBill = price;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
        
        //Update detail of Bill - Parking Fee
        public async Task<int> UpdateParkingFee(string id, decimal price)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.ParkingFee = price;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
        
        //Update detail of Bill - Room
        public async Task<int> UpdateRoomBil(string id, decimal price)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.RoomBill = price;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
        
        //Update detail of Bill - IDMotel
        public async Task<int> UpdateIdMotel(string id, int idmotel)
        {
            var result = _context.InforBills.Find(id);
            if (string.IsNullOrEmpty(id) || result == null || !GetMotelRoomList().Contains(idmotel))
                throw new MotelExceptions("Enter your value or value dont exist");
            else
            {
                result.ElectricBill = idmotel;
                _context.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
