using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.BillPayment.Dtos
{
    public class Bill : BillRequest
    {
        public decimal PaymentTotal { get; set; }
    }
}
