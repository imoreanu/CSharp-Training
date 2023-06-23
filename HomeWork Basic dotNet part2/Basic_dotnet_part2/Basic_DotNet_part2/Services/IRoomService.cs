using WebApplication1.DataTransferObject;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IRoomService
    {
        public Task AddRoom(RoomDto roomDto);

        bool RoomExists(int id);
        public Room GetRoomById(int id);

        public Task RemoveRoomById(int id);
    }
}
