using Motel.Application.Category.RoomMotel.Dtos;
using Motel.EntityDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.RoomMotel
{
    public class ManageRoomMotel : IManageRoomMotel
    {
        private readonly MotelDbContext _context;

        public ManageRoomMotel(MotelDbContext context)
        {
            _context = context;
        }

        public Task<int> Create(RoomRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Find(int id)
        {
            throw new NotImplementedException();
        }

        public ViewModelRoom<Room> GetAll()
        {
            throw new NotImplementedException();
        }

        public ViewModelRoom<Room> GetEmptyRoom()
        {
            throw new NotImplementedException();
        }

        public ViewModelRoom<Room> GetRoomByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(RoomRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateArea(int id, int area)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateInfor(int id, int bedroom, int toilet)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePayment(int id, decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
