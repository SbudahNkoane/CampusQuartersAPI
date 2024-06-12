using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly CampusQuartersDataContext _dataContext;
        public AccommodationRepository(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Accommodation> CreateAccommodationAsync(Accommodation accommodation)
        {
            await _dataContext.Accommodations.AddAsync(accommodation);
            await _dataContext.SaveChangesAsync();
            return accommodation;
        }

        public async Task<Accommodation?> DeleteAccommodationAsync(int id)
        {
            var accommodation = await _dataContext.Accommodations
                .Include(accommodation => accommodation.Type)
                .Include(accommodation => accommodation.Images)
                .Include(accommodation => accommodation.Availability)
                .FirstOrDefaultAsync(x => x.Id == id);
            if(accommodation == null)
            {
                return null;
            }
            _dataContext.Accommodations.Remove(accommodation);

            if (accommodation.Availability != null)
               _dataContext.Availability.Remove(accommodation.Availability);

            if (accommodation.Images != null)
            {
                foreach (var image in accommodation.Images)
                {
                    _dataContext.AccommodationImages.Remove(image);
                }
            }
            if (accommodation.Videos != null)
            {
                foreach (var video in accommodation.Videos)
                {
                    _dataContext.AccommodationVideos.Remove(video);
                }
            }
            await _dataContext.SaveChangesAsync();
            return accommodation;

        }

        public async Task<Accommodation?> GetAccommodationByIdAsync(int id)
        {
            return await _dataContext.Accommodations.FindAsync(id);
        }

        public async Task<List<Accommodation>> GetAllAccommodationsAsync()
        {
            return await _dataContext.Accommodations
                     .Include(accommodation => accommodation.Type)
                     .Include(accommodation => accommodation.Availability)
                     .Include(accommodation => accommodation.Availability.Status)
                     .Include(createAccommodation => createAccommodation.Landlord)
                     .Include(accommodation => accommodation.Videos)
                     .Include(accommodation => accommodation.Images)
                    .ToListAsync();
        }
    }
}
