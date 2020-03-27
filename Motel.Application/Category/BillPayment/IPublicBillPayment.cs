using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using System.Threading.Tasks;

namespace Motel.Application.Category.BillPayment
{
    public interface IPublicBillPayment
    {
        Bill GetBill(string id);
    }
}
