using Motel.EntityDb.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.RoomMotel
{
    public class ManageRoomMotel : IManageRoomMotel
    {
        private readonly MotelDbContext _context;

        public ManageRoomMotel(MotelDbContext context)
        {
            _context = context;
        }

    }
}
