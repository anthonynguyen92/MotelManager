using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class Customer
    {
        [Key]
        public Guid IDuser { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        public String Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public String Address { get; set; }
        [Required]
        public String PhoneNumber { get; set; }
        [Required]
        public String Identification { get; set; }
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        public virtual Rent Rent { get; set; }
    }
}
