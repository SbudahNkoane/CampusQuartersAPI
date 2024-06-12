using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Dtos.Photographer;
using CampusQuartersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IPhotographerRepository
    {
        Task<List<Photographer>> GetAllPhotographersAsync();
        Task<Photographer?> GetPhotographerByIdAsync(int id);
        Task<Photographer> CreatePhotographerAsync(Photographer photographer);
        Task<Photographer?> UpdatePhotographerAsync(int id, UpdatePhotographerDto updatePhotographerDto);
        Task<Photographer?> DeletePhotographerAsync(int id);
    }
}
