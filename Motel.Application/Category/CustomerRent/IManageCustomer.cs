using Motel.Application.Category.BillPayment.Dtos;
using Motel.Application.Category.CustomerRent.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.CustomerRent
{
    public interface IManageCustomer
    {
        // Create - with all information of Rent customer
        Task<int> Create(CustomerRequest customer);

        // Update - all information of customer 
        Task<int> Update(string id,CustomerRequest customer);
        
        // Delete - a customer with id input
        Task<int> Delete(string id);
        
        // Find - a customer with id input 
        Task<Customer> Find(String id);
        
        // Update - first name && last name with id customer input
        Task<int> UpdateName(string id,string fname,string lname);
        
        // Update - update sex with id input
        Task<int> UpdateSex(string id ,string sex);
        
        // Update - Address wiht id input
        Task<int> UpdateAddress(string id ,string address);
        
        // Update - PhoneNumber with id input
        Task<int> UpdatePhoneNumber(string id,string number);
        
        // Update - Identification with id input
        Task<int> UpdateIdentification(string id,string idfi);
        
        // Update -Email with idinput
        Task<int> UpdateEmail(string id,string email);
        
        // Get All list Customer - who rents
        Task<PagedViewModel<CustomerRequest>> GettAll();
        
        // Get all list by name 
        Task<PagedViewModel<CustomerRequest>> GetByFirstName(String name);

        // Get id for user by find by name
        string GetIDbyRequest(CustomerRequest request);
        /*
         * need a func which return a list of customer by using pagination.
         */
    }
}
