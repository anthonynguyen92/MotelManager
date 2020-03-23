using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.BillPayment.Dtos
{
    public class BillPaymentCreate
    {
        public string Id { get; set; }
        public int MonthRent { get; set; }
        public decimal WaterBill { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal WifiBill { get; set; }
        public decimal ParkingFee { get; set; }
        public decimal RoomBil { get; set; }
    }
}
