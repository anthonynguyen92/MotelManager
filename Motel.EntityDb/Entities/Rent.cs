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
        public String IdRent { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int idMotel { get; set; }
        public virtual MotelRoom MotelRoom { get; set; }
        public string IDcustomer { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
