using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer;
using WebApplication1.DataAccessLayer.Repositories;
using WebApplication1.DataTransferObject;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomService _roomService;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepository roomRepository, IRoomService roomService, DataContext dataContext, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _roomService = roomService;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Route("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            await _roomService.AddRoom(roomDto);

            return Ok();
        }

        [HttpGet]
        [Route("/GetRooms")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Room>))]
        public IActionResult GetRooms()
        {
            var rooms = _roomRepository.GetRooms();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rooms);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(int roomId, [FromBody] Room roomUpdated)
        {
            var room = await _dataContext.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);

            // check if the hotel is null and return Not found
            if (room is null) // hotel == null
            {
                return NotFound($"The room with id {roomId} does not exists.");
            }

            room.Number = roomUpdated.Number;
            room.HotelId = roomUpdated.HotelId;
            room.IsAvailable = roomUpdated.IsAvailable;

            _dataContext.Rooms.Update(room);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                await _roomService.RemoveRoomById(id);

                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
