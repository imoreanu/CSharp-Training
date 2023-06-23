using Microsoft.EntityFrameworkCore;
using WebApplication1.DataTransferObject;
using WebApplication1.Entities;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _dataContext;

        public RoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool RoomExists(int roomId)
        {
            return _dataContext.Rooms.Any(r => r.Id == roomId);
        }

        public Room GetRoomById(int roomlId)
        {
            return _dataContext.Rooms.Where(r => r.Id == roomlId).FirstOrDefault();
        }

        public IEnumerable<Room> GetRooms()
        {
            return _dataContext.Rooms.OrderBy(r => r.Id).ToList();
        }

        public bool TryGetRoom(int id, out Room room)
        {
            room = GetRooms().FirstOrDefault(r => r.Id == id);
            return room != null;
        }

        public IEnumerable<Room> GetAvailableRooms()
        {
            foreach (var room in GetRooms())
            {
                Thread.Sleep(10);
                yield return room;
            }
        }

        public async Task<Room> AddAsync(Room room)
        {
            var createdRoomEntity = await _dataContext.Rooms.AddAsync(room);
            await _dataContext.SaveChangesAsync();

            return createdRoomEntity.Entity;
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _dataContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task DeleteAsync(Room room)
        {
            _dataContext.Rooms.Remove(room);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _dataContext.Rooms.Update(room);
            await _dataContext.SaveChangesAsync();
        }
    }
}
