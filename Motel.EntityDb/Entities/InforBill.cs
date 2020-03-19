using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motel.EntityDb.Entities
{
    public class InforBill
    {
        public Guid Id { get; set; }
        public int MonthRent { get; set; }
        public decimal WaterBill { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal WifiBill { get; set; }
        public decimal ParkingFee { get; set; }
        public decimal RoomBil { get; set; }
        [ForeignKey("IDRoom")]
        public virtual MotelRoom MotelRoom { get; set; }

    }
}
