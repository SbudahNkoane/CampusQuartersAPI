using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Models;

namespace DomainLayer.Interfaces
{
    public interface ILandlordRepository
    {
        Task<List<Landlord>> GetAllLandlordsAsync();
        Task<Landlord?> GetLandlordByIdAsync(int id);
        Task<Landlord> CreateLandlordAsync(Landlord landlord);
        Task<Landlord?> UpdateLandlordAsync(int id, UpdateLandlordDto updateLandlordDto);
        Task<Landlord?> DeleteLandlordAsync(int id);
    }
}
