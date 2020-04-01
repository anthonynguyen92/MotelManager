using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.BillPayment.Dtos
{
    public class BillRequest
    {
        public string Id { get; set; }
        public int MonthRent { get; set; }
        public decimal WaterBill { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal WifiBill { get; set; }
        public decimal ParkingFee { get; set; }
        public decimal RoomBil { get; set; }
        public int IdMotel { get; set; }
        public bool Payment { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DatePay { get; set; }

    }
}
