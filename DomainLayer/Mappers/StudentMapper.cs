using CampusQuartersAPI.Dtos.Student;
using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                StudentNumber = student.StudentNumber,
                Surname = student.Surname,
                CellNumber = student.CellNumber,
                EmailAddress = student.EmailAddress,
                AccountId = student.AccountId,
            };
        }
        public static Student ToStudentFromCreateDto(this CreateStudentDto createStudent)
        {
            return new Student
            {
                EmailAddress = createStudent.EmailAddress,
                Name = createStudent.Name,
                CellNumber = createStudent.CellNumber,
                StudentNumber = createStudent.StudentNumber,
                Surname = createStudent.Surname,
                Account = new Account
                {
                    Password = createStudent.Account.Password,
                    RoleId = 1,
                }
            };
        }
    }
}
