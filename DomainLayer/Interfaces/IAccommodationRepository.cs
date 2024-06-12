using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IAccommodationRepository
    {
        Task<List<Accommodation>> GetAllAccommodationsAsync();
        Task<Accommodation?> GetAccommodationByIdAsync(int id);
        Task<Accommodation> CreateAccommodationAsync(Accommodation accommodation);
       // Task<Accommodation?> UpdateAccommodationAsync(int id, Upd);
        Task<Accommodation?> DeleteAccommodationAsync(int id);
    }
}
