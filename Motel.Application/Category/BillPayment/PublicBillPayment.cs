using System;
using System.Collections.Generic;
using System.Text;
using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;

namespace Motel.Application.Category.BillPayment
{
    public class PublicBillPayment : IPublicBillPayment
    {
        public PagedViewModel<BillPaymentViewModel> GetAllByBillPayment(GetBillPaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
