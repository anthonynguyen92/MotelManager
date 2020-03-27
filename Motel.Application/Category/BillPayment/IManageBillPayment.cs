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
        Task<int> Create(BillPaymentRequest create,int id);
        Task<int> Update(BillPaymentRequest update);
        Task<int> UpdateMonthRent(string id,int price);
        Task<int> UpdateWaterBill(string id, decimal price);
        Task<int> UpdateElectricBill(string id, decimal price);
        Task<int> UpdateWifiBill(string id, decimal price);
        Task<int> UpdateParkingFee(string id, decimal price);
        Task<int> UpdateRoomBil(string id, decimal price);
        Task<int> UpdateIdMotel(string id, int idmotel);
        Task<int> Delete(string id);
        Task<BillPaymentRequest> Find(string id);
        Task<PagedViewModel<BillPaymentRequest>> GetAllBillpayment();
        // need fix this func
        Task<PagedViewModel<BillPaymentRequest>> GetAllPaging();
        List<int> GetMotelRoomList();
        Task<PagedViewModel<BillPaymentRequest>> GetPayment();
        Task<bool> UpdatPayment(string id,decimal totalmoney);
        Task<PagedViewModel<BillPaymentRequest>> GetPaymentDone();
    }
}
