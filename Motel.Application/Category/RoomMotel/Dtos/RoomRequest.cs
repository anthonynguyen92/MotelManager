using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.RoomMotel.Dtos
{
    public class RoomRequest
    {
        public int idMotel { get; set; }
        public String NameRoom { get; set; }
        public int BedRoom { get; set; }
        public int Toilet { get; set; }
        public int Area { get; set; }
        public bool Status { get; set; }
        public decimal Payment { get; set; }    
    }
}
