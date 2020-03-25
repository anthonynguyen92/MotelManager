using Motel.Application.Category.CustomerRent.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.CustomerRent
{
    public interface IManageCustomer
    {
        Task<int> Create(CustomerRequest customer);
        Task<int> Update(string id,CustomerRequest customer);
        Task<int> Delete(string id);
        CustomerRequest Find(String id);
        Task<int> UpdateName(string id,string fname,string lname);
        Task<int> UpdateSex(string id ,string sex);
        Task<int> UpdateAddress(string id ,string address);
        Task<int> UpdatePhoneNumber(string id,string number);
        Task<int> UpdateIdentification(string id,string idfi);
        Task<int> UpdateEmail(string id,string email);
        List<CustomerRequest> GettAll();

        /*
         * need a func which return a list of customer by using pagination.
         */

    }
}
