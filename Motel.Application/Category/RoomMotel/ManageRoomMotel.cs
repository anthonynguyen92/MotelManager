using Microsoft.EntityFrameworkCore;
using Motel.Application.Category.RoomMotel.Dtos;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using Motel.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Motel.Application.Category.RoomMotel
{
    public class ManageRoomMotel : IManageRoomMotel
    {
        private readonly MotelDbContext _context;

        public ManageRoomMotel(MotelDbContext context)
        {
            _context = context;
        }

        // Create Room 
        public async Task<int> Create(RoomRequest request)
        {
                var result = new MotelRoom()
                {
                    
                    Area = request.Area,
                    BedRoom = request.BedRoom,
                    NameRoom = request.NameRoom,
                    Payment = request.Payment,
                    Status = false,
                    Toilet = request.Toilet
                };
                _context.MotelRooms.Add(result);
            return await _context.SaveChangesAsync();
        }

        // Delete a Room with id
        public async Task<int> Delete(int id)
        {
            var ans = _context.MotelRooms.Find(id);
            if (ans == null)
                throw new MotelExceptions("?");
            else
                _context.MotelRooms.Remove(ans);
            return await _context.SaveChangesAsync();
        }

        // Get - All room
        public async Task<ViewModelRoom<Room>> GetAll()
        {
            var getroom = from c in _context.MotelRooms
                          orderby c.BedRoom
                          select c;
            var data = new ViewModelRoom<Room>()
            {
                Items = getroom.Select(x => new Room()
                {
                    Area = x.Area,
                    BedRoom = x.BedRoom,
                    idMotel = x.idMotel,
                    NameRoom = x.NameRoom,
                    Payment = x.Payment,
                    Status = x.Status,
                    Toilet = x.Toilet
                }).ToList(),
                TotalRecord = await getroom.CountAsync(),
            };
            return data;
        }

        //Get Room with empty Room
        public async Task<ViewModelRoom<Room>> GetEmptyRoomAsync()
        {
            var getroom = from c in _context.MotelRooms
                          orderby c.BedRoom
                          where c.Status == false
                          select c;
            var data = new ViewModelRoom<Room>()
            {
                Items = getroom.Select(x => new Room()
                {
                    Area = x.Area,
                    BedRoom = x.BedRoom,
                    idMotel = x.idMotel,
                    NameRoom = x.NameRoom,
                    Payment = x.Payment,
                    Status = x.Status,
                    Toilet = x.Toilet
                }).ToList(),
                TotalRecord = await getroom.CountAsync(),
            };
            return data;
        }

        // Get Room wiht name contains
        public async Task<ViewModelRoom<Room>> GetRoomByName(string name)
        {
            var getroom = from c in _context.MotelRooms
                          orderby c.BedRoom
                          where c.NameRoom.Contains(name)
                          select c;
            var data = new ViewModelRoom<Room>()
            {
                Items = getroom.Select(x => new Room()
                {
                    Area = x.Area,
                    BedRoom = x.BedRoom,
                    idMotel = x.idMotel,
                    NameRoom = x.NameRoom,
                    Payment = x.Payment,
                    Status = x.Status,
                    Toilet = x.Toilet
                }).ToList(),
                TotalRecord = await getroom.CountAsync(),
            };
            return data;
        }

        // Update a room - all property
        public async Task<int> Update(RoomRequest request)
        {
            var check = _context.MotelRooms.Find(request.idMotel);
            if (check == null) throw new MotelExceptions("??");
            else
            {
                check.NameRoom = request.NameRoom;
                check.Payment = request.Payment;
                check.Status = request.Status;
                check.Toilet = request.Toilet;
                _context.MotelRooms.Update(check);
            }
            return await _context.SaveChangesAsync();
        }

        //Update - Area
        public async Task<int> UpdateArea(int id, int area)
        {
            var request = _context.MotelRooms.Find(id);
            if (request == null) throw new MotelExceptions($"? {id}");
            else
            {
                request.Area = area;
                _context.MotelRooms.Update(request);
            }
            return await _context.SaveChangesAsync();
        }

        // Update - Infor room
        public async Task<int> UpdateInfor(int id, int bedroom, int toilet)
        {
            var request = _context.MotelRooms.Find(id);
            if (request == null) throw new MotelExceptions($"? {id}");
            else
            {
                request.BedRoom = bedroom;
                request.Toilet = toilet;
                _context.MotelRooms.Update(request);
            }
            return await _context.SaveChangesAsync();
        }

        // Update - Name
        public async Task<int> UpdateName(int id, string name)
        {
            var request = _context.MotelRooms.Find(id);
            if (request == null) throw new MotelExceptions($"? {id}");
            else
            {
                request.NameRoom = name;
                _context.MotelRooms.Update(request);
            }
            return await _context.SaveChangesAsync();
        }

        // Update - Price Room
        public async Task<int> UpdatePayment(int id, decimal price)
        {
            var request = _context.MotelRooms.Find(id);
            if (request == null) throw new MotelExceptions($"? {id}");
            else
            {
                request.Payment = price;
                _context.MotelRooms.Update(request);
            }
            return await _context.SaveChangesAsync();
        }

        // Update - Status
        public async Task<int> UpdateStatus(int id)
        {
            var request = _context.MotelRooms.Find(id);
            if (request == null) throw new MotelExceptions($"? {id}");
            else
            {
                if (request.Status)
                    request.Status = false;
                else request.Status = true;
                _context.MotelRooms.Update(request);
            }
            return await _context.SaveChangesAsync();
        }

        // Find - return a Room
        public RoomRequest Find(int id)
        {
            var result = _context.MotelRooms.Find(id);
            if (result == null) throw new MotelExceptions($"? Chang mày giảm cân đi chứ mập lắm rồi");
            else
            {
                RoomRequest data = new RoomRequest()
                {
                    Area = result.Area,
                    BedRoom = result.BedRoom,
                    idMotel = result.idMotel,
                    NameRoom = result.NameRoom,
                    Payment = result.Payment,
                    Status = result.Status,
                    Toilet = result.Toilet,
                };
                return data;
            }
        }
    }
}
