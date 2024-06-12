using CampusQuartersAPI.Dtos.Account;

namespace CampusQuartersAPI.Dtos.Landlord
{
    public class CreateLandlordDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int CellNumber { get; set; }
        public CreateAccountDto Account { get; set; }
    }
}
