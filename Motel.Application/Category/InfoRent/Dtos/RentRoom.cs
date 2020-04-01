using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.InfoRent.Dtos
{
    public class RentRoom
    {
        public string idrent { get; set; }
        public int idmotel { get; set; }
        public string NameRoom { get; set; }
        public DateTime DateStart { get; set; }
    }
}
