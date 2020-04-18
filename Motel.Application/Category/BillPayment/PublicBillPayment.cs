using Motel.Application.Category.BillPayment.Dtos;
using Motel.EntityDb.EF;

namespace Motel.Application.Category.BillPayment
{
    public class PublicBillPayment : IPublicBillPayment
    {
        private readonly MotelDbContext _context;

        public PublicBillPayment(MotelDbContext contex)
        {
            _context = contex;
        }

        // All infor and money
        public Bill GetBill(string id)
        {
            var result = _context.InforBills.Find(id);
            Bill data = new Bill()
            {
                DateCreate = result.DateCreate,
                //DatePay = result.DatePay.Value,
                ElectricBill = result.ElectricBill,
                Id = result.IdInforBill,
                IdMotel = result.IdMotel,
                MonthRent = result.MonthRent,
                ParkingFee = result.ParkingFee,
                Payment = result.Payment,
                RoomBil = result.RoomBill,
                WifiBill = result.WifiBill,
                WaterBill = result.WaterBill,
                PaymentTotal = result.WaterBill + result.WifiBill + result.ParkingFee + result.RoomBill,
            };
            return data;
        }
    }
}
