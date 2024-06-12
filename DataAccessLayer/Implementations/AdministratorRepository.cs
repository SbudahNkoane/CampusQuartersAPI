using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Administrator;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Implementations
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly CampusQuartersDataContext _dataContext;
        public AdministratorRepository(CampusQuartersDataContext dataContext) 
        {
            _dataContext = dataContext;
        }


        public async Task<Administrator> CreateAdministratorAsync(Administrator administrator)
        {
            await _dataContext.Administrators.AddAsync(administrator);
            await _dataContext.SaveChangesAsync();
            return administrator;
        }

        public async Task<Administrator?> DeleteAdministratorAsync(int id)
        {
            var administratorEntity = await _dataContext.Administrators
                                          .Include(a => a.Account)
                                          .FirstOrDefaultAsync(s => s.Id == id);
            if (administratorEntity == null)
            {
                return null;
            }
            _dataContext.Administrators.Remove(administratorEntity);
            _dataContext.Account.Remove(administratorEntity.Account);
            await _dataContext.SaveChangesAsync();

            return administratorEntity;
        }

        public async Task<Administrator?> GetAdministratorByIdAsync(int id)
        {
            return await _dataContext.Administrators.FindAsync(id);
        }

        public async Task<List<Administrator>> GetAllAdministratorsAsync()
        {
            return await _dataContext.Administrators.ToListAsync();
        }

        public async Task<Administrator?> UpdateAdministratorAsync(int id, UpdateAdministratorDto updateAdministratorDto)
        {
            var adminEntity = await _dataContext.Administrators.FindAsync(id);
            if (adminEntity == null)
            {
                return null;
            }

            adminEntity.Surname = updateAdministratorDto.Surname;
            adminEntity.CellNumber = updateAdministratorDto.CellNumber;
            adminEntity.Name = updateAdministratorDto.Name;

            await _dataContext.SaveChangesAsync();
            return adminEntity;
        }
    }
}
