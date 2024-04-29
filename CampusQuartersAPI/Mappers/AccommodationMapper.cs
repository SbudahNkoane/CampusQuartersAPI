using CampusQuartersAPI.Dtos.Accommodation;
using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Mappers
{
    public static class AccommodationMapper
    {
        public static AccommodationDto ToAccommodationDto(this Accommodation accommodation)
        {
            return new AccommodationDto
            {
                Id = accommodation.Id,
                Address = accommodation.Address,
                AvailabilityId = accommodation.AvailabilityId,
                Created = accommodation.Created,
                Deposit = accommodation.Deposit,
                Description = accommodation.Description,
                //To-Do: Map images to imagesDto
                Images = accommodation.Images,
                LandlordId = accommodation.LandlordId,
                Name = accommodation.Name,
                Photographed = accommodation.Photographed,
                Rent = accommodation.Rent,
                TypeId = accommodation.TypeId,
                //To-Do: Map images to imagesDto
                Videos = accommodation.Videos,
            };
        }

        public static Accommodation ToAccommodationFromCreateDto(this CreateAccommodationDto createAccommodationDto)
        {
            return new Accommodation
            {
                Name = createAccommodationDto.Name,
                LandlordId = createAccommodationDto.LandlordId,
                Address = createAccommodationDto.Address,
                Created = DateTime.Now,
                Availability = new Availability
                {
                    DateAvailable = createAccommodationDto.Availability.DateAvailable,
                    IsAvailable = createAccommodationDto.Availability.IsAvailable,
                    StatusId = createAccommodationDto.Availability.StatusId,
                },
                Description = createAccommodationDto.Description,
                Deposit = createAccommodationDto.Deposit,
                Rent = createAccommodationDto.Rent,
                TypeId = createAccommodationDto.TypeId,

            };
        }
    }
}
