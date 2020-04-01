using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Motel.Application.Category.InfoRent.Dtos;
using Motel.Application.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Application.Category.InfoRent
{
    public class ManageRent : IManageRent
    {
        private readonly MotelDbContext _context;
        private List<string> IDcustomer
        {
            get
            {
                var result = from c in _context.Rents
                             select c.IDcustomer;
                return result.ToList();
            }
        }
        private List<int> IDMotel
        {
            get
            {
                var result = from c in _context.Rents
                             select c.idMotel;
                return result.ToList();
            }
        }
        private List<string> ID
        {
            get
            {
                var result = from c in _context.Rents
                             select c.IdRent;
                return result.ToList();
            }
        }
        private List<int> getMotel
        {
            get
            {
                var result = from c in _context.MotelRooms
                             select c.idMotel;
                return result.ToList();
            }
        }
        private List<string> getCustomer
        {
            get
            {
                var result = from c in _context.Customers
                             select c.IDuser;
                return result.ToList();
            }
        }

        public ManageRent(MotelDbContext contex)
        {
            _context = contex;
        }
        public async Task<int> Create(string id, string idcustomer, int idmotel)
        {
            if (!getCustomer.Contains(idcustomer) && !getMotel.Contains(idmotel))
                return 0;
            if (!ID.Contains(id) && !IDcustomer.Contains(idcustomer) && !IDMotel.Contains(idmotel))
            {
                var rent = new Rent()
                {
                    IdRent = id,
                    idMotel = idmotel,
                    IDcustomer = idcustomer,
                    Start = DateTime.Now,
                };
                _context.Rents.Add(rent);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> Delete(string id)
        {
            if (ID.Contains(id))
            {
                var result = _context.Rents.Find(id);
                if (result != null)
                {
                    _context.Rents.Remove(result);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            return 0;
        }

        public async Task<PagedViewModel<RentRequest>> GetByEndDate()
        {
            var request = from c in _context.Rents
                          where c.End != null
                          select c;
            PagedViewModel<RentRequest> data = new PagedViewModel<RentRequest>()
            {
                Items = request.Select(x => new RentRequest()
                {
                    IdRent = x.IdRent,
                    IDcustomer = x.IDcustomer,
                    End = x.End.Value,
                    idMotel = x.idMotel,
                    Start = x.Start
                }).ToList(),
                TotalRecord = await request.CountAsync(),
            };
            return data;
        }

        // need check
        public RentRequest GetById(string id)
        {
            if (ID.Contains(id))
            {
                var result = _context.Rents.Find(id);
                if (result != null)
                {
                    var data = new RentRequest()
                    {
                        //End = result.End.Value.,
                        IDcustomer =result.IDcustomer,
                        idMotel =result.idMotel,
                        IdRent =result.IdRent,
                        Start =result.Start
                    };
                    return data;
                }
            }
            return null;
        }

        // remember test
        public async Task<string> GetByIDMotel(int id)
        {
            if (!IDMotel.Contains(id))
                return null;
            var request = from c in _context.Rents
                          where c.idMotel ==id
                          select c;
            PagedViewModel<RentRequest> data = new PagedViewModel<RentRequest>()
            {
                Items = request.Select(x => new RentRequest()
                {
                    IdRent = x.IdRent,
                    IDcustomer = x.IDcustomer,
                    End = x.End.Value,
                    idMotel = x.idMotel,
                    Start = x.Start
                }).ToList(),
                TotalRecord = await request.CountAsync(),
            };
            var kq = data.Items;
            return kq.FirstOrDefault().IDcustomer.ToString();
        }

        public async Task<int> GetByIdUser(string iduser)
        {
            if (!IDcustomer.Contains(iduser))
                return 0;
            var request = from c in _context.Rents
                          where c.IDcustomer == iduser
                          select c;
            PagedViewModel<RentRequest> data = new PagedViewModel<RentRequest>()
            {
                Items = request.Select(x => new RentRequest()
                {
                    IdRent = x.IdRent,
                    IDcustomer = x.IDcustomer,
                    End = x.End.Value,
                    idMotel = x.idMotel,
                    Start = x.Start
                }).ToList(),
                TotalRecord = await request.CountAsync(),
            };
            var kq = data.Items;
            return (int)kq.FirstOrDefault().idMotel;
        }

        public async Task<int> Update(RentRequest request, string id)
        {
            if(ID.Contains(id))
            {
                var result = _context.Rents.Find(id);
                if (result != null)
                {
                    result.idMotel = request.idMotel;
                    result.IDcustomer = request.IDcustomer;
                    result.Start = request.Start;
                    result.End = request.End;
                    _context.Rents.Update(result);
                    return await _context.SaveChangesAsync();
                }
            }
            return 0;
        }

        public async Task<int> UpdateDate(string id, DateTime date)
        {
            if(ID.Contains(id))
            {
                var result = _context.Rents.Find(id);
                if (result != null)
                {
                    result.Start = date;
                    _context.Rents.Update(result);
                    return await _context.SaveChangesAsync();
                }
            }
            return 0;
        }

        // after customer end of constract => call this funct
        public async Task<int> UpdateDateEnd(string id, DateTime date)
        {
            if (ID.Contains(id))
            {
                var result = _context.Rents.Find(id);
                if (result != null)
                {
                    result.End = date;
                    _context.Rents.Update(result);
                    return await _context.SaveChangesAsync();
                }
            }
            return 0;
        }

        public async Task<int> UpdateIdCustomer(string id, string idcustomer)
        {
            if (!IDcustomer.Contains(idcustomer))
            {
                if (ID.Contains(id))
                {
                    var result = _context.Rents.Find(id);
                    if (result != null)
                    {
                        result.IDcustomer = idcustomer;
                        _context.Rents.Update(result);
                        return await _context.SaveChangesAsync();
                    }
                }
            }
            return 0;
        }

        public async Task<int> UpdateIdMotel(string id, int idmotel)
        {
            if (!IDMotel.Contains(idmotel) && idmotel>0)
            {
                if (ID.Contains(id))
                {
                    var result = _context.Rents.Find(id);
                    if (result != null)
                    {
                        result.idMotel =idmotel;
                        _context.Rents.Update(result);
                        return await _context.SaveChangesAsync();
                    }
                }
            }
            return 0;
        }

        public async Task<PagedViewModel<RentUser>> GetRoom(string iduser)
        {
            if (IDcustomer.Contains(iduser))
            {
                var result = from c in _context.Rents
                             join m in _context.Customers on c.IDcustomer equals m.IDuser
                             where c.IDcustomer == iduser
                             select new { c, m };
                var data = new PagedViewModel<RentUser>()
                {
                    Items = result.Select(x => new RentUser()
                    {
                        idmotel = x.c.idMotel,
                        idrent = x.c.IdRent,
                        iduser = x.c.IDcustomer,
                        Name = x.m.FirstName + " " + x.m.LastName,
                    }).ToList(),
                    TotalRecord = await result.CountAsync(),
                };
                return data;
            }
            return null;

        }

        public async Task<PagedViewModel<RentRoom>> GetRoom(int idroom)
        {
            if (IDMotel.Contains(idroom))
            {
                var result = from r in _context.Rents
                             join m in _context.MotelRooms on r.idMotel equals m.idMotel
                             where r.idMotel == idroom
                             select new { r, m };
                var data = new PagedViewModel<RentRoom>()
                {
                    Items = result.Select(x => new RentRoom()
                    {
                        DateStart = x.r.Start,
                        idmotel =x.r.idMotel,
                        idrent = x.r.IdRent,
                        NameRoom = x.m.NameRoom
                    }).ToList(),
                    TotalRecord = await result.CountAsync(),
                };
                return data;
            }
            return null;
        }
    }
}
