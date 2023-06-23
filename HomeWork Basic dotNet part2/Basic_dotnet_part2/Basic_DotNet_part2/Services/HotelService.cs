namespace WebApplication1.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.DataAccessLayer;
    using WebApplication1.DataAccessLayer.Repositories;
    using WebApplication1.DataTransferObject;
    using WebApplication1.Entities;
    using WebApplication1.Exceptions;

    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, DataContext dataContext, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _dataContext = dataContext;
            _mapper = mapper;

        }

        public async Task AddHotel(HotelDto hotelDto)
        {
            var mappedData = MapHotelData(hotelDto);

            await _hotelRepository.AddAsync(mappedData);
        }

        public Hotel GetHotelById(int id)
        {
            return _dataContext.Hotels.Where(h => h.Id == id).FirstOrDefault();
        }

        public bool HotelExists(int id)
        {
            return _dataContext.Hotels.Any(h => h.Id == id);
        }

        public async Task RemoveHotelById(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel is null)
            {
                throw new NotFoundException($"The hotel with the given id: '{id}' was not found");
            }

            await _hotelRepository.DeleteAsync(hotel);
        }

        private static Hotel MapHotelData(HotelDto hotelDto)
        {
            return new Hotel
            {
                Name = hotelDto.Name,
                Stars = hotelDto.Stars,
                City = hotelDto.City,
                Country = hotelDto.Country,
                Description = hotelDto.Description,
            };
        }

        private HotelDto MapHotelData(Hotel hotel)
        {
            return new HotelDto
            {
                Name = hotel.Name,
                Stars = hotel.Stars,
                City = hotel.City,
                Country = hotel.Country,
                Description = hotel.Description,
            };
        }
    }
}
