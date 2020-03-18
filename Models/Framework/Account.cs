using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Framework
{
    [Table("Acount")]
    public partial class Account
    {
        [Key]
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(30)]
        public String Password { get; set; }

    }
}
