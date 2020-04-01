using Motel.Application.Category.InfoRent.Dtos;
using Motel.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.InfoRent
{
    public interface IManageRent
    {
        Task<int> Create(string id, string idcustomer, int idmotel);
        Task<int> Delete(string id);
        Task<int> Update(RentRequest request, string id);
        Task<int> UpdateDate(string id, DateTime date);
        Task<int> UpdateDateEnd(string id, DateTime date);
        Task<int> UpdateIdMotel(string id, int idmotel);
        Task<int> UpdateIdCustomer(String id, string idcustomer);
        RentRequest GetById(string id);
        Task<string> GetByIDMotel(int id);
        Task<int> GetByIdUser(string iduser);
        Task<PagedViewModel<RentRequest>> GetByEndDate();
        Task<PagedViewModel<RentUser>> GetRoom(string iduser);
        Task<PagedViewModel<RentRoom>> GetRoom(int idroom);

        // havent add
       

    }
}
