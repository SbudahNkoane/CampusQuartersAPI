using CampusQuartersAPI.Dtos.Account;

namespace CampusQuartersAPI.Dtos.Photographer
{
    public class CreatePhotographerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int CellNumber { get; set; }
        public CreateAccountDto Account { get; set; }
    }
}
