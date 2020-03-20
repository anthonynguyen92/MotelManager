using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motel.EntityDb.Entities
{
    public class MotelRoom
    {
        public Guid id { get; set; }
        public String NameRoom { get; set; }
        [Required]
        public int BedRoom { get; set; }
        public int Toilet { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public decimal Payment { get; set; }
        public virtual Rent Rent { get; set; }
        public virtual List<InforBill> InforBills { get; set; }
    }
}
