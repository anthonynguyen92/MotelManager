using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.InfoRent.Dtos
{
    public class RentRequest
    {
        public String IdRent { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int idMotel { get; set; }
        public string IDcustomer { get; set; }
    }
}
