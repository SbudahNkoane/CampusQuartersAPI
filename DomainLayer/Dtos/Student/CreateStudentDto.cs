using CampusQuartersAPI.Dtos.Account;

namespace CampusQuartersAPI.Dtos.Student
{
    public class CreateStudentDto
    {
        public string Name { get; set; }= string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public int CellNumber { get; set; }
        public int StudentNumber { get; set; }
        public CreateAccountDto Account { get; set; }
    }
}
