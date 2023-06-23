using WebApplication1.Entities;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public interface IRoomRepository
    {
        public Task<Room> AddAsync(Room room);
        public IEnumerable<Room> GetRooms();
        public Task<Room> GetByIdAsync(int id);
        public bool RoomExists(int roomId);
        public bool TryGetRoom(int id, out Room room);
        public IEnumerable<Room> GetAvailableRooms();
        public Task UpdateAsync(Room room);
        public Task DeleteAsync(Room room);
    }
}
