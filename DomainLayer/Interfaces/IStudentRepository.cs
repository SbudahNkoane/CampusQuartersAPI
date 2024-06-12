using CampusQuartersAPI.Dtos.Student;
using CampusQuartersAPI.Models;

namespace DomainLayer.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student?> UpdateStudentAsync(int id,UpdateStudentDto updateStudentDto);
        Task<Student?> DeleteStudentAsync(int id);
    }
}
