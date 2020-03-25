using Microsoft.EntityFrameworkCore;
using Motel.Application.Category.CustomerRent.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using Motel.Utilities.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Application.Category.CustomerRent
{
    public class ManageCustomer : IManageCustomer
    {
        private readonly MotelDbContext _context;
        public ManageCustomer(MotelDbContext context)
        {
            _context = context;
        }

        // valid email - customer - identification - phone number
        public async Task<int> Create(CustomerRequest customer)
        {
            var resultid = _context.Customers.Find(customer.IDuser);
            //var resultiden = _context.Customers.Find(customer.Identification);
            if (resultid != null)// || resultiden == null)
                throw new MotelExceptions($"{customer.Identification} or ${customer.IDuser} exist please enter another id");
            else
            {
                var kq = new Customer()
                {
                    IDuser = customer.IDuser,
                    Identification = customer.Identification,
                    Address = customer.Address,
                    Birthdate = customer.Birthdate,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Sex = customer.Sex,
                };
                _context.Customers.Add(kq);
            }
            return await _context.SaveChangesAsync();
        }

        // need return name delete 
        public async Task<int> Delete(string id)
        {
            var result = _context.Customers.Find(id);
            if (result == null) throw new MotelExceptions("Your id dont exist, please enter your trust id");
            else
                _context.Customers.Remove(result);
            return await _context.SaveChangesAsync();
        }

        public CustomerRequest Find(string id)
        {
            var result = _context.Customers.Find(id);
            if (result == null) throw new MotelExceptions("Your user dont have exist.");
            else
            {
                CustomerRequest cs = new CustomerRequest()
                {
                    Address = result.Address,
                    Birthdate = result.Birthdate,
                    Email = result.Email,
                    FirstName = result.FirstName,
                    Identification = result.Identification,
                    IDuser = result.IDuser,
                    LastName = result.LastName,
                    PhoneNumber = result.PhoneNumber,
                    Sex = result.Sex,
                };
                return cs;
            }
        }

        public async Task<PagedViewModel<CustomerRequest>> GettAll()
        {
            var request = from c in _context.Customers
                          orderby c.IDuser
                          select c;
            PagedViewModel<CustomerRequest> list = new PagedViewModel<CustomerRequest>()
            {
                Items = request.Select(x => new CustomerRequest()
                {
                    Address = x.Address,
                    Birthdate = x.Birthdate,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    Identification = x.Identification,
                    IDuser = x.IDuser,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Sex = x.Sex,
                }).ToList(),
                TotalRecord = await request.CountAsync(),
            };
            return list;
        }

        public async Task<int> Update(string id, CustomerRequest customer)
        {
            var request = _context.Customers.Find(customer.IDuser);
            if (request == null) throw new MotelExceptions("Chiu den ca id cung nhap sai thi chiu @@@@@@");
            else
            {
                request.LastName = customer.LastName;
                request.Identification = customer.Identification;
                request.FirstName = customer.FirstName;
                request.Address = customer.Address;
                request.Birthdate = customer.Birthdate;
                request.Email = customer.Email;
                request.Sex = customer.Sex;
                request.PhoneNumber = customer.PhoneNumber;
                _context.Customers.Update(request);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAddress(string id, string address)
        {
            var result = _context.Customers.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("just an id but you still enter wrong? need review yourself!");
            else
            {
                result.Address = address;
                _context.Customers.Update(result);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEmail(string id, string email)
        {
            var result = _context.Customers.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("just an id but you still enter wrong? need review yourself!");
            else
            {
                result.Email = email;
                _context.Customers.Update(result);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateIdentification(string id, string idfi)
        {
            var result = _context.Customers.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("just an id but you still enter wrong? need review yourself!");
            else
            {
                result.Identification = idfi;
                _context.Customers.Update(result);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateName(string id, string fname, string lname)
        {
            var result = _context.Customers.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("just an id but you still enter wrong? need review yourself!");
            else
            {
                result.FirstName = fname;
                result.LastName = lname;
                _context.Customers.Update(result);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePhoneNumber(string id, string number)
        {
            var result = _context.Customers.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("just an id but you still enter wrong? need review yourself!");
            else
            {
                result.PhoneNumber = number;
                _context.Customers.Update(result);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSex(string id, string sex)
        {
            var result = _context.Customers.Find(id);
            if (string.IsNullOrEmpty(id) || result == null)
                throw new MotelExceptions("just an id but you still enter wrong? need review yourself!");
            else
            {
                result.Sex = sex;
                _context.Customers.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
