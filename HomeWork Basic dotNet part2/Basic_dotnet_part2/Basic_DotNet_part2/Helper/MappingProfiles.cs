using AutoMapper;
using WebApplication1.DataTransferObject;
using WebApplication1.Entities;

namespace WebApplication1.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<Reservation, ReservationDto>();
        }
    }
}
