using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class Rent
    {
        [Key]
        public Guid IdRent { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        //public Guid RefMotel { get; set; }
        //public Guid RefCustomer { get; set; }
        [ForeignKey("FKMotel")]
        public virtual MotelRoom MotelRoom { get; set; }
        [ForeignKey("FKCustomer")]
        public virtual Customer Customer { get; set; }
    }
}
