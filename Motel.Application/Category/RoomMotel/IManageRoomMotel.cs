using Motel.Application.Category.RoomMotel.Dtos;
using System.Threading.Tasks;

namespace Motel.Application.Category.RoomMotel
{
    public interface IManageRoomMotel
    {
        Task<int> Create(RoomRequest request);
        Task<int> Find(int id);
        Task<int> Update(RoomRequest request);
        Task<int> Delete(int id);
        Task<int> UpdateName(int id, string name);
        Task<int> UpdatePayment(int id, decimal price);
        Task<int> UpdateStatus(int id);
        Task<int> UpdateInfor(int id, int bedroom, int toilet);
        Task<int> UpdateArea(int id, int area);
        ViewModelRoom<Room> GetAll();
        ViewModelRoom<Room> GetEmptyRoom();

    }
}
