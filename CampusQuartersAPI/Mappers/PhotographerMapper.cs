using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Dtos.Photographer;
using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Mappers
{
    public static class PhotographerMapper
    {
        public static PhotographerDto ToPhotographerDto(this Photographer photographer)
        {
            return new PhotographerDto
            {
                Id = photographer.Id,
                Name = photographer.Name,
                Surname = photographer.Surname,
                EmailAddress = photographer.EmailAddress,
                CellNumber = photographer.CellNumber,
                AccountId = photographer.AccountId,
            };
        }
        public static Photographer ToPhotographerFromCreateDto(this CreatePhotographerDto createPhotographer)
        {
            return new Photographer
            {

                EmailAddress = createPhotographer.EmailAddress,
                Name = createPhotographer.Name,
                CellNumber = createPhotographer.CellNumber,
                Surname = createPhotographer.Surname,
                Account = new Account
                {
                    Password = createPhotographer.Account.Password,
                    RoleId = 1,
                }
            };
        }
    }
}
