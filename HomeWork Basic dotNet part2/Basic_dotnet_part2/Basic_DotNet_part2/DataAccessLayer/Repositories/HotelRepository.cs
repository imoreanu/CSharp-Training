namespace WebApplication1.DataAccessLayer.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using WebApplication1.Entities;

    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext _dataContext;

        public HotelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            var createdHotelEntity = await _dataContext.Hotels.AddAsync(hotel);
            await _dataContext.SaveChangesAsync();

            return createdHotelEntity.Entity;
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _dataContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            return await _dataContext.Hotels.ToListAsync();
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            _dataContext.Hotels.Update(hotel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Hotel hotel)
        {
            _dataContext.Hotels.Remove(hotel);
            await _dataContext.SaveChangesAsync();
        }

        ICollection<Hotel> IHotelRepository.GetAllActiveHotels()
        {
            return _dataContext.Hotels.OrderBy(h => h.Id).ToList();
        }
    }
}
