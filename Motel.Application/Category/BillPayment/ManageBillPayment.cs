using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;

namespace Motel.Application.Category.BillPayment
{
    public class ManageBillPayment : IManageBillPayment
    {
        private readonly MotelDbContext _context;
        public ManageBillPayment(MotelDbContext context)
        {
            _context = context;
        }

        // this's api dont have motelroomid and u must add.
        public async Task<int> Create(BillPaymentCreate create)
        {

            var bill = new InforBill()
            {
                Id = create.Id,
                ElectricBill = create.ElectricBill,
                MonthRent = create.MonthRent,
                ParkingFee = create.ParkingFee,
                RoomBil = create.RoomBil,
                WaterBill = create.WaterBill,
                WifiBill = create.WifiBill,
            };
            _context.InforBills.Add(bill);
            return await _context.SaveChangesAsync();
        }


        //Input is a guid so u need find and change true value.
        public async Task<int> Delete(BillPaymentDelete delete)
        {
            var list = _context.InforBills.Find(delete);
            if (list != null)
                _context.InforBills.Remove(list);
            return await _context.SaveChangesAsync();
        }

        // this func replace all value in update and some value is null, maybe it's will change -> null
        // so i need fix the problem soon.!!!!!
        public async Task<int> Update(BillPaymentUpdate update)
        {
            var value = _context.InforBills.Find(update.Id);
            if (value != null)
            {
                value.ElectricBill = update.ElectricBill;
                value.MonthRent = update.MonthRent;
                value.ParkingFee = update.ParkingFee;
                value.RoomBil = update.RoomBil;
                value.WaterBill = update.WaterBill;
                value.WifiBill = update.WifiBill;
            }
            return await _context.SaveChangesAsync();
        }

        // to api dont have oop so i cant write api=> await :)))
        public async Task<List<BillPaymentViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedViewModel<BillPaymentViewModel>> GetAllPaging(int pIndex, int pSize)
        {
            throw new NotImplementedException();
        }


    }
}
