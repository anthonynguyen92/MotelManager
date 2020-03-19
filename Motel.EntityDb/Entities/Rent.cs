using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class Rent
    {
        public String IdRent { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        [ForeignKey("IDRoom")]
        public virtual MotelRoom MotelRoom { get; set; }
        [ForeignKey("IDuser")]
        public virtual Customer Customer { get; set; }
    }
}
