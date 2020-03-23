using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Dtos
{
    public class PaginRequestBase
    {
        public int PIndex { get; set; }
        public int PSize { get; set; }
    }
}
