using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;

namespace Motel.Application.Category.BillPayment
{
    public class ManageBillPayment : IManageBillPayment
    {
        private readonly MotelDbContext _context;
        public ManageBillPayment(MotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(BillPaymentCreate create)
        {
            var bill = new InforBill()
            {
                //MotelRoom = create.,
            };
            _context.InforBills.Add(bill);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(BillPaymentDelete delete)
        {
            throw new NotImplementedException();
        }

        public Task<List<BillPaymentViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedViewModel<BillPaymentViewModel>> GetAllPaging(int pIndex, int pSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(BillPaymentUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
