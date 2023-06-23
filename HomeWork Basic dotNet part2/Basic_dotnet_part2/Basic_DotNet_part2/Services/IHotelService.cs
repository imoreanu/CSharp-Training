namespace WebApplication1.Services
{
    using WebApplication1.DataTransferObject;
    using WebApplication1.Entities;

    public interface IHotelService
    {
        public Task AddHotel(HotelDto hotelDto);

        bool HotelExists(int id);
        public Hotel GetHotelById(int id);

        public Task RemoveHotelById(int id);
    }
}
