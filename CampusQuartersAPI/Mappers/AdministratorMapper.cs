using CampusQuartersAPI.Dtos.Administrator;
using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Mappers
{
    public static class AdministratorMapper
    {
        public static AdministratorDto ToAdministratorDto(this Administrator administrator)
        {
            return new AdministratorDto
            {
                Id = administrator.Id,
                Name = administrator.Name,
                Surname = administrator.Surname,
                EmailAddress = administrator.EmailAddress,
                CellNumber = administrator.CellNumber,
                AccountId = administrator.AccountId,
            };
        }
        public static Administrator ToAdministratorFromCreateDto(this CreateAdministratorDto createAdministrator)
        {
            return new Administrator
            {

                EmailAddress = createAdministrator.EmailAddress,
                Name = createAdministrator.Name,
                CellNumber = createAdministrator.CellNumber,
                Surname = createAdministrator.Surname,
                Account = new Account
                {
                    Password = createAdministrator.Account.Password,
                    RoleId = 2,
                }
            };
        }
    }
}
