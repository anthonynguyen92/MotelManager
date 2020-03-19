using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class Manager
    {
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public String FirstName { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
