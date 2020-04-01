using Motel.Application.Category.FamilyGroups.Dtos;
using Motel.Application.Dtos;
using System.Threading.Tasks;

namespace Motel.Application.Category.FamilyGroups
{
    public interface IManageFamily
    {
        // Create - with all information of Rent customer
        Task<int> Create(FamilyRequest request);

        // Update - all information of customer 
        Task<int> Update(string id, FamilyRequest request);

        // Delete - a customer with id input
        Task<int> Delete(string id);

        // Find - a customer with id input 
        FamilyRequest Find(string id);

        // Update - first name && last name with id customer input
        Task<int> UpdateName(string id, string fname, string lname);

        // Update - update sex with id input
        Task<int> UpdateSex(string id, string sex);

        // Update - Address wiht id input
        Task<int> UpdateAddress(string id, string address);

        // Update - PhoneNumber with id input
        Task<int> UpdatePhoneNumber(string id, string number);

        // Update - Identification with id input
        Task<int> UpdateIdentification(string id, string idfi);

        // Update - Id
        Task<int> UpdateUser(string id, string iduser);

        // Get All list Customer - who rents
        Task<PagedViewModel<FamilyRequest>> GettAll();

        // Get all list by name 
        Task<PagedViewModel<FamilyRequest>> GetByFirstName(string name);

        // Get - by User ->  person host rent house
        Task<PagedViewModel<FamilyRequest>> GetByUserID(string userid);
    }
}
