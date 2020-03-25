using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.BillPayment
{
    public interface IPublicBillPayment
    {
        PagedViewModel<BillPaymentRequest> GetAllByBillPayment(BillPaymentRequest request);
    }
}
