using Motel.Application.Category.RoomMotel.Dtos;
using System.Threading.Tasks;

namespace Motel.Application.Category.RoomMotel
{
    public interface IManageRoomMotel
    {
        // Create - new room
        Task<int> Create(RoomRequest request);
        
        // Find - a room with id
        RoomRequest Find(int id);

        // Update - all infor room
        Task<int> Update(RoomRequest request);
        
        // Delete - a room with id
        Task<int> Delete(int id);
        
        // Update - Name room with id
        Task<int> UpdateName(int id, string name);
        
        // Update - payment with id
        Task<int> UpdatePayment(int id, decimal price);
        
        // Update status room - true -> false or false -> true
        Task<int> UpdateStatus(int id);
        
        // Update - infor room : bedroom - toilet ...
        Task<int> UpdateInfor(int id, int bedroom, int toilet);
        
        // Update - Area with id
        Task<int> UpdateArea(int id, int area);
        
        // Get - All rooms
        Task<ViewModelRoom<Room>> GetAll();
        
        // Get - All Empty rooms
        Task<ViewModelRoom<Room>> GetEmptyRoomAsync();
        
        // Get - All room with Name Room
        Task<ViewModelRoom<Room>> GetRoomByName(string name);

    }
}
