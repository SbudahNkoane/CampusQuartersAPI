using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Dtos.Photographer;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class PhotographerRepository : IPhotographerRepository
    {
        private readonly CampusQuartersDataContext _dataContext;
        public PhotographerRepository(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Photographer> CreatePhotographerAsync(Photographer photographer)
        {
            await _dataContext.Photographers.AddAsync(photographer);
            await _dataContext.SaveChangesAsync();
            return photographer;
        }

        public async Task<Photographer?> DeletePhotographerAsync(int id)
        {
            var photographerEntity = await _dataContext.Photographers
                                                         .Include(a => a.Account)
                                                         .FirstOrDefaultAsync(s => s.Id == id);

            if (photographerEntity == null)
            {
                return null;
            }
            _dataContext.Photographers.Remove(photographerEntity);
            _dataContext.Account.Remove(photographerEntity.Account);
            await _dataContext.SaveChangesAsync();

            return photographerEntity;
        }

        public async Task<List<Photographer>> GetAllPhotographersAsync()
        {
            return await _dataContext.Photographers.ToListAsync();
        }

        public async Task<Photographer?> GetPhotographerByIdAsync(int id)
        {
            return await _dataContext.Photographers.FindAsync(id);
        }

        public async Task<Photographer?> UpdatePhotographerAsync(int id, UpdatePhotographerDto updatePhotographerDto)
        {
            var photographerEntity = await _dataContext.Photographers.FindAsync(id);
            if (photographerEntity == null)
            {
                return null;
            }

            photographerEntity.Surname = updatePhotographerDto.Surname;
            photographerEntity.CellNumber = updatePhotographerDto.CellNumber;
            photographerEntity.Name = updatePhotographerDto.Name;

            await _dataContext.SaveChangesAsync();
            return photographerEntity;
        }
    }
}
