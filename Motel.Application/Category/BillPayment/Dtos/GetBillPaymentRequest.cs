using Motel.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.BillPayment.Dtos
{
    public class GetBillPaymentRequest : PaginRequestBase
    {
        public String kw { get; set; }
        public List<int> Categoryid { get; set; }
    }
}
