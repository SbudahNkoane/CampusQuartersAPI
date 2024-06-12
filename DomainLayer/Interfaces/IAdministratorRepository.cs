using CampusQuartersAPI.Dtos.Administrator;
using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<List<Administrator>> GetAllAdministratorsAsync();
        Task<Administrator?> GetAdministratorByIdAsync(int id);
        Task<Administrator> CreateAdministratorAsync(Administrator administrator);
        Task<Administrator?> UpdateAdministratorAsync(int id, UpdateAdministratorDto updateAdministratorDto);
        Task<Administrator?> DeleteAdministratorAsync(int id);
    }
}
