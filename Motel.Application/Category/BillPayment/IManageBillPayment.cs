using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.Entities;
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
        Task<int> UpdateMontRent(string id,int price);
        Task<int> UpdateWaterBill(string id, decimal price);
        Task<int> UpdateElectricBill(string id, decimal price);
        Task<int> UpdateWifiBill(string id, decimal price);
        Task<int> UpdateParkingFee(string id, decimal price);
        Task<int> UpdateRoomBil(string id, decimal price);
        Task<int> UpdateIdMotel(string id, int idmotel);

        Task<int> Delete(BillPaymentDelete delete);

        Task<BillPaymentFind> Find(string id);
        Task<PagedViewModel<BillPaymentViewModel>> GetAllBillpayment();
        Task<PagedViewModel<BillPaymentViewModel>> GetAllPaging(GetBillPaymentRequest request);
        List<int> GetMotelRoomList();
    }
}
