using Microsoft.EntityFrameworkCore;
using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Application.Category.BillPayment
{
    public class ManageBillPayment : IManageBillPayment
    {
        private readonly MotelDbContext _context;
        private List<int> IDmotel
        {
            get
            {
                var result = from c in _context.MotelRooms
                             select c.idMotel;
                return result.ToList();
            }
        }
        private List<string> IDBill
        {
            get
            {
                var result = from c in _context.InforBills
                             select c.IdInforBill;
                return result.ToList();
            }
        }
        public ManageBillPayment(MotelDbContext context)
        {
            _context = context;
        }

        /*
         * id is a value of motel room and u must get id for it
         */
        // POST: create a bill payment
        public async Task<int> Create(BillRequest create, int id)
        {
            if (!IDmotel.Contains(create.IdMotel))
                return 0;
            if (!IDBill.Contains(create.Id))
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
                    Payment = false,
                    DateCreate = DateTime.Now,
                };
                _context.InforBills.Add(bill);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        // DELETE: delete a bill payment
        public async Task<int> Delete(string id)
        {
            var bill = _context.InforBills.Find(id);
            if (bill == null) return 0;
            else _context.InforBills.Remove(bill);
            return await _context.SaveChangesAsync();
        }

        // GET Update - have more and more infor so u need add s.th func, example : update money ....
        public async Task<int> Update(BillRequest update)
        {
            var bill = _context.InforBills.Find(update.Id);
            if (bill == null)
                return 0;
            else
            {
                if (!IDmotel.Contains(update.IdMotel))
                    return 0;
                else
                {
                    bill.ElectricBill = update.ElectricBill;
                    bill.IdMotel = update.IdMotel;
                    bill.MonthRent = update.MonthRent;
                    bill.ParkingFee = update.ParkingFee;
                    bill.RoomBill = update.ParkingFee;
                    bill.WaterBill = update.WaterBill;
                    bill.WifiBill = update.WifiBill;
                    _context.InforBills.Update(bill);
                    return await _context.SaveChangesAsync();
                }
            }
        }

        //GET All Paging
        public async Task<PagedViewModel<BillRequest>> GetAllPaging()
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
            var request = from c in _context.InforBills
                          orderby c.IdInforBill
                          select c;

            PagedViewModel<BillRequest> list = new PagedViewModel<BillRequest>()
            {
                Items = request.Select(x => new BillRequest()
                {
                    ElectricBill = x.ElectricBill,
                    Id = x.IdInforBill,
                    IdMotel = x.IdMotel,
                    MonthRent = x.MonthRent,
                    ParkingFee = x.ParkingFee,
                    RoomBil = x.RoomBill,
                    WaterBill = x.WaterBill,
                    WifiBill = x.WifiBill,
                    Payment = x.Payment,
                    DateCreate = x.DateCreate
                }).ToList(),
                TotalRecord = await request.CountAsync(),
            };
            return list;
        }

        // GET Find an id bill - enter true id and it's will return if not => null
        public async Task<BillRequest> Find(string id)
        {
            var result = await _context.InforBills.FindAsync(id);
            if (result == null)
                return null;
            var value = new BillRequest()
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
            if (price <= 0)
                return 0;
            var result = _context.InforBills.Find(id);
            if (result == null)
                return 0;
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
            if (price <= 0)
                return 0;
            var result = _context.InforBills.Find(id);
            if (result == null)
                return 0;
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
            if (price <= 0)
                return 0;
            var result = _context.InforBills.Find(id);
            if (result == null)
                return 0;
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
            if (price <= 0)
                return 0;
            var result = _context.InforBills.Find(id);
            if (result == null)
                return 0;
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
            if (price <= 0)
                return 0;
            var result = _context.InforBills.Find(id);
            if (result == null)
                return 0;
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
            if (price <= 0)
                return 0;
            var result = _context.InforBills.Find(id);
            if (result == null)
                return 0;
            else
            {
                result.RoomBill = price;
                _context.Update(result);
                return await _context.SaveChangesAsync();
            }
        }

        //Update detail of Bill - IDMotel
        public async Task<int> UpdateIdMotel(string id, int idmotel)
        {
            if (IDmotel.Contains(idmotel))
            {
                var result = _context.InforBills.Find(id);
                if (result != null)
                {
                    result.ElectricBill = idmotel;
                    _context.Update(result);
                    return await _context.SaveChangesAsync();
                }
            }
            return 0;
        }

        //Haven't been Payment motel
        public async Task<PagedViewModel<BillRequest>> GetPayment()
        {
            var result = from c in _context.InforBills
                         where c.Payment == false
                         select c;
            var data = new PagedViewModel<BillRequest>()
            {
                Items = result.Select(x => new BillRequest()
                {
                    ElectricBill = x.ElectricBill,
                    Id = x.IdInforBill,
                    IdMotel = x.IdMotel,
                    MonthRent = x.MonthRent,
                    ParkingFee = x.ParkingFee,
                    RoomBil = x.RoomBill,
                    WaterBill = x.WaterBill,
                    WifiBill = x.WifiBill,
                    Payment = x.Payment,
                    DateCreate = x.DateCreate,
                }).ToList(),
                TotalRecord = await result.CountAsync(),
            };
            return data;
        }

        // Update payment -> true = payment bill
        public async Task<bool> UpdatPayment(string id, decimal totalmoney)
        {
            var result = _context.InforBills.Find(id);
            if (result != null)
            {
                decimal value = result.ElectricBill + result.ParkingFee
                    + result.RoomBill + result.WaterBill + result.WifiBill;
                if (value == totalmoney)
                {
                    result.Payment = true;
                    result.DatePay = DateTime.Now;
                    _context.InforBills.Update(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        // Get infobil payment
        public async Task<PagedViewModel<BillRequest>> GetPaymentDone()
        {
            var result = from c in _context.InforBills
                         where c.Payment == true && c.DatePay != null
                         select c;
            var data = new PagedViewModel<BillRequest>()
            {
                Items = result.Select(x => new BillRequest()
                {
                    ElectricBill = x.ElectricBill,
                    Id = x.IdInforBill,
                    IdMotel = x.IdMotel,
                    MonthRent = x.MonthRent,
                    ParkingFee = x.ParkingFee,
                    RoomBil = x.RoomBill,
                    WaterBill = x.WaterBill,
                    WifiBill = x.WifiBill,
                    Payment = x.Payment,
                    DateCreate = x.DateCreate,
                }).ToList(),
                TotalRecord = await result.CountAsync(),
            };
            return data;
        }

        // Get Info bill payment by id
        public async Task<PagedViewModel<BillRequest>> GetByIDMotel(int value)
        {
            if (!IDmotel.Contains(value))
                return null;
            var result = from c in _context.InforBills
                         where c.IdMotel == value
                         select c;
            var data = new PagedViewModel<BillRequest>()
            {
                Items = result.Select(x => new BillRequest()
                {
                    ElectricBill = x.ElectricBill,
                    Id = x.IdInforBill,
                    IdMotel = x.IdMotel,
                    MonthRent = x.MonthRent,
                    ParkingFee = x.ParkingFee,
                    RoomBil = x.RoomBill,
                    WaterBill = x.WaterBill,
                    WifiBill = x.WifiBill,
                    Payment = x.Payment,
                    DateCreate = x.DateCreate,
                }).ToList(),
                TotalRecord = await result.CountAsync(),
            };
            return data;
        }
    }
}
