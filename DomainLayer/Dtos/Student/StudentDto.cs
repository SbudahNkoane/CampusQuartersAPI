using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int CellNumber { get; set; }
        public int StudentNumber { get; set; }
        public int? AccountId { get; set; }
    }
}
