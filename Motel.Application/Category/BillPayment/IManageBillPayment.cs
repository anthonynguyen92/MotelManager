using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.BillPayment
{
    public interface IManageBillPayment
    {
        Task<int> Create(BillPaymentCreate create);
        Task<int> Update(BillPaymentUpdate update);
        Task<int> Delete(BillPaymentDelete delete);
        Task<List<BillPaymentViewModel>> GetAll();
        Task<PagedViewModel<BillPaymentViewModel>> GetAllPaging(int pIndex, int pSize);
    }
}
