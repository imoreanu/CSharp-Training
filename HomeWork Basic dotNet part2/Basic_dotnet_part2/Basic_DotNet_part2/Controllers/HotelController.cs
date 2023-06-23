using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccessLayer.Repositories;

namespace WebApplication1.Controllers
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.DataAccessLayer;
    using WebApplication1.DataTransferObject;
    using WebApplication1.Entities;
    using WebApplication1.Exceptions;
    using WebApplication1.Services;

    [ApiController]
    [Route("api/hotels")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IHotelRepository _hotelRepository;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IHotelRepository hotelRepository, DataContext dataContext, IMapper mapper)
        {
            _hotelService = hotelService;
            _hotelRepository = hotelRepository;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        // Create new hotel method
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Route("CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotelDto)
        {
            await _hotelService.AddHotel(hotelDto);

            return Ok();
        }

        // Get all hotels
        [HttpGet]
        [Route("/GetAllActiveHotels")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hotel>))]
        public IActionResult GetAllActiveHotels()
        {
            var hotels = _hotelRepository.GetAllActiveHotels();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hotels);
        }

        // Get a specific hotel based on id
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Hotel))]
        [ProducesResponseType(400)]
        [Route("GetHotelById")]  // api/hotel/1
        public IActionResult GetHotelById(int id)
        {
            if (!_hotelService.HotelExists(id))
                return NotFound($"The Hotel with Id {id} does not exists");

            var hotel = _mapper.Map<HotelDto>(_hotelService.GetHotelById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hotel);
        }

        // Delete a specific hotel
        [HttpDelete]
        [Route("DeleteHotel")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotelService.RemoveHotelById(id);
                
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

        // Get hotels with rooms
        [HttpGet]
        [Route("rooms")] //api/hotels/rooms
        public async Task<IActionResult> GetHotelsWithRooms()
        {
            var hotels = await _dataContext.Hotels.Include(h => h.Rooms).ToListAsync();

            return Ok(hotels);
        }

        // Update a specific hotel
        [HttpPut]
        public async Task<IActionResult> UpdateHotel(int hotelId, [FromBody] Hotel hotelUpdated)
        {
            var hotel = await _dataContext.Hotels.FirstOrDefaultAsync(h => h.Id == hotelId);

            // check if the hotel is null and return Not found
            if (hotel is null) // hotel == null
            {
                return NotFound($"The hotel with id {hotelId} does not exists.");
            }

            hotel.Name = hotelUpdated.Name;
            hotel.Stars = hotelUpdated.Stars;
            hotel.Country = hotelUpdated.Country;
            hotel.City = hotelUpdated.City;
            hotel.Description = hotelUpdated.Description;

            _dataContext.Hotels.Update(hotel);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
