using AutoMapper;
using WebApplication1.DataAccessLayer.Repositories;
using WebApplication1.DataAccessLayer;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
using WebApplication1.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, DataContext dataContext, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _dataContext = dataContext;
            _mapper = mapper;

        }

        public async Task AddRoom(RoomDto roomDto)
        {
            var mappedData = MapRoomData(roomDto);

            await _roomRepository.AddAsync(mappedData);
        }

        public Room GetRoomById(int id)
        {
            return _dataContext.Rooms.Where(r => r.Id == id).FirstOrDefault();
        }

        public bool RoomExists(int id)
        {
            return _dataContext.Rooms.Any(r => r.Id == id);
        }

        public async Task RemoveRoomById(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException($"The room with the given id: '{id}' was not found");
            await _roomRepository.DeleteAsync(room);
        }

        private static Room MapRoomData(RoomDto roomDto)
        {
            return new Room
            {
                Number = roomDto.Number,
                HotelId = roomDto.HotelId,
                IsAvailable = roomDto.IsAvailable,
            };
        }

        private static RoomDto MapRoomData(Room room)
        {
            return new RoomDto
            {
                Number = room.Number,
                HotelId = room.HotelId,
                IsAvailable = room.IsAvailable,
            };
        }
    }
}
