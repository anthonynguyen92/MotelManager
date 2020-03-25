using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.RoomMotel.Dtos
{
    public class ViewModelRoom<T>
    {
        public List<T> Items;
        public int TotalRecord;
    }
}
