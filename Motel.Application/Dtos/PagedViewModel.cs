using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Dtos
{
    public class PagedViewModel<T>
    {
        List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
