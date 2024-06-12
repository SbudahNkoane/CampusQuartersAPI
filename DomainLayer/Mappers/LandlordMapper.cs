using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Models;
using System.Runtime.CompilerServices;

namespace CampusQuartersAPI.Mappers
{
    public static class LandlordMapper
    {
        public static LandlordDto ToLandlordDto(this Landlord landlord)
        {
            return new LandlordDto
            {
                Id = landlord.Id,
                 Name = landlord.Name,
                 Surname = landlord.Surname,
                 EmailAddress = landlord.EmailAddress,
                 CellNumber = landlord.CellNumber,
                 AccountId = landlord.AccountId,
            };
        }
        public static Landlord ToLandlordFromCreateDto(this CreateLandlordDto createLandlord)
        {
            return new Landlord
            {
                
                EmailAddress = createLandlord.EmailAddress,
                Name = createLandlord.Name,
                CellNumber = createLandlord.CellNumber,
                Surname = createLandlord.Surname,
                Account = new Account
                {
                    Password = createLandlord.Account.Password,
                    RoleId = 1,
                }
            };
        }
    }
}
