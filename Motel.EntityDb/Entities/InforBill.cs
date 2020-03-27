using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motel.EntityDb.Entities
{
    public class InforBill
    {
        public String IdInforBill { get; set; }
        public int MonthRent { get; set; }
        public decimal WaterBill { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal WifiBill { get; set; }
        public decimal ParkingFee { get; set; }
        public decimal RoomBill { get; set; }
        public virtual MotelRoom MotelRoom { get; set; }
        public int IdMotel { get; set; }
        public bool Payment { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DatePay { get; set; }
    }
}
