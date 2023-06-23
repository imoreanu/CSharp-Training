namespace WebApplication1.DataAccessLayer.Repositories
{
    using WebApplication1.Entities;

    public interface IHotelRepository
    {
        public Task<Hotel> AddAsync(Hotel hotel);

        public Task<Hotel> GetByIdAsync(int id);

        public ICollection<Hotel> GetAllActiveHotels();

        public Task UpdateAsync(Hotel hotel);

        Task DeleteAsync(Hotel hotel);
    }
}
