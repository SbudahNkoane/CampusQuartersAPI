namespace CampusQuartersAPI.Dtos.Student
{
    public class UpdateStudentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int CellNumber { get; set; }
        public int StudentNumber { get; set; }
    }
}
