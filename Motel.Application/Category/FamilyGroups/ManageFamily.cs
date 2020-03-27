using Microsoft.EntityFrameworkCore;
using Motel.Application.Category.FamilyGroups.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using Motel.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Motel.Application.Category.FamilyGroups
{
    public class ManageFamily : IManageFamily
    {
        private readonly MotelDbContext _context;

        public ManageFamily(MotelDbContext contex)
        {
            _context = contex;
        }

        public async Task<int> Create(FamilyRequest request)
        {
            var check = _context.Families.Find(request.Id);
            if (!getlist().Contains(request.User))
                throw new MotelExceptions("?");
            if (check != null) throw new MotelExceptions("?");
            else
            {
                FamilyGroup fg = new FamilyGroup()
                {
                    Address = request.Address,
                    Birthday = request.Birthday,
                    FirstName = request.FirstName,
                    Id = request.Id,
                    Identification = request.Identification,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Sex = request.Sex,
                    User = request.User,
                };
                _context.Families.Add(fg);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(string id)
        {
            var check = _context.Families.Find(id);
            if (check == null)
                throw new MotelExceptions("?");
            else
            {
                _context.Families.Remove(check);
                return await _context.SaveChangesAsync();
            }
        }

        public FamilyRequest Find(string id)
        {
            var result = _context.Families.Find(id);
            FamilyRequest kq = new FamilyRequest()
            {
                Address = result.Address,
                Birthday = result.Birthday,
                FirstName = result.FirstName,
                Id = result.Id,
                Identification = result.Identification,
                LastName = result.LastName,
                PhoneNumber = result.PhoneNumber,
                Sex = result.Sex,
                User = result.User
            };
            return kq;
        }

        public async Task<PagedViewModel<FamilyRequest>> GetByFirstName(string name)
        {
            var result = from c in _context.Families
                         where c.FirstName.Contains(name)
                         orderby c.Id
                         select c;
            PagedViewModel<FamilyRequest> list = new PagedViewModel<FamilyRequest>()
            {
                Items = result.Select(x => new FamilyRequest()
                {
                    Address = x.Address,
                    Birthday = x.Birthday,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    Identification = x.Identification,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Sex = x.Sex,
                    User = x.User
                }).ToList(),
                TotalRecord = await result.CountAsync(),
            };
            return list;
        }

        public async Task<PagedViewModel<FamilyRequest>> GettAll()
        {
            var result = from c in _context.Families
                         orderby c.Id
                         select c;
            PagedViewModel<FamilyRequest> list = new PagedViewModel<FamilyRequest>()
            {
                Items = result.Select(x => new FamilyRequest()
                {
                    Address = x.Address,
                    Birthday = x.Birthday,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    Identification = x.Identification,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Sex = x.Sex,
                    User = x.User
                }).ToList(),
                TotalRecord = await result.CountAsync(),
            };
            return list;
        }

        public async Task<int> Update(string id, FamilyRequest request)
        {
            var check = _context.Families.Find(id);
            if (check == null) throw new MotelExceptions("?");
            else
            {
                check.Address = request.Address;
                check.Birthday = request.Birthday;
                check.FirstName = request.FirstName;
                check.Id = request.Identification;
                check.LastName = request.LastName;
                check.PhoneNumber = request.PhoneNumber;
                check.Sex = request.Sex;
                check.User = request.User;
                _context.Families.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAddress(string id, string address)
        {
            var check = _context.Families.Find(id);
            if (check == null) throw new MotelExceptions("?");
            else
            {
                check.Address = address;
                _context.Families.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateIdentification(string id, string idfi)
        {
            var check = _context.Families.Find(id);
            if (check == null) throw new MotelExceptions("?");
            else
            {
                check.Identification = idfi;
                _context.Families.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateName(string id, string fname, string lname)
        {
            var check = _context.Families.Find(id);
            if (check == null) throw new MotelExceptions("?");
            else
            {
                check.FirstName = fname;
                check.LastName = lname;
                _context.Families.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePhoneNumber(string id, string number)
        {
            var check = _context.Families.Find(id);
            if (check == null) throw new MotelExceptions("?");
            else
            {
                check.PhoneNumber = number;
                _context.Families.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSex(string id, string sex)
        {
            var check = _context.Families.Find(id);
            if (check == null) throw new MotelExceptions("?");
            else
            {
                check.Sex = sex;
                _context.Families.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        private List<string> getlist()
        {
            var result = from c in _context.Customers
                         select c.IDuser;
            return result.ToList();
        }

        public Task<PagedViewModel<FamilyRequest>> GetByUserID(string userid)
        {
            throw new NotImplementedException();
        }
    }
}
