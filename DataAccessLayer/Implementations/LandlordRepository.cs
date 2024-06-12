using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Dtos.Student;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class LandlordRepository : ILandlordRepository
    {
        private readonly CampusQuartersDataContext _dataContext;
        public LandlordRepository(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Landlord> CreateLandlordAsync(Landlord landlord)
        {
            await _dataContext.Landlords.AddAsync(landlord);
            await _dataContext.SaveChangesAsync();
            return landlord;
        }

        public async Task<Landlord?> DeleteLandlordAsync(int id)
        {
            var landlordEntity = await _dataContext.Landlords
             .Include(a => a.Account)
             .FirstOrDefaultAsync(s => s.Id == id);
            if (landlordEntity == null)
            {
                return null;
            }
            _dataContext.Landlords.Remove(landlordEntity);
            _dataContext.Account.Remove(landlordEntity.Account);
            await _dataContext.SaveChangesAsync();

            return landlordEntity;
        }

        public async Task<List<Landlord>> GetAllLandlordsAsync()
        {
            return await _dataContext.Landlords.ToListAsync();
        }

        public async Task<Landlord?> GetLandlordByIdAsync(int id)
        {
            return await _dataContext.Landlords.FindAsync(id);
        }

        public async Task<Landlord?> UpdateLandlordAsync(int id, UpdateLandlordDto updateLandlordDto)
        {
            var landlordEntity = await _dataContext.Landlords.FindAsync(id);
            if (landlordEntity == null)
            {
                return null;
            }

            landlordEntity.Surname = updateLandlordDto.Surname;
            landlordEntity.CellNumber = updateLandlordDto.CellNumber;
            landlordEntity.Name = updateLandlordDto.Name;

            await _dataContext.SaveChangesAsync();
            return landlordEntity;
        }
    }
}
