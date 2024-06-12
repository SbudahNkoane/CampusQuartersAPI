using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Student;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CampusQuartersDataContext _dataContext;
        public StudentRepository(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _dataContext.Students.AddAsync(student);
            await _dataContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteStudentAsync(int id)
        {
            var studentEntity = await _dataContext.Students
                .Include(a => a.Account)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (studentEntity == null) 
            { 
                return null; 
            }
            _dataContext.Students.Remove(studentEntity);
            _dataContext.Account.Remove(studentEntity.Account);
            await _dataContext.SaveChangesAsync();

            return studentEntity;
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _dataContext.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _dataContext.Students.ToListAsync();
        }

        public async Task<Student?> UpdateStudentAsync(int id, UpdateStudentDto updateStudentDto)
        {
            var studentEntity = await _dataContext.Students.FindAsync(id);
            if (studentEntity == null) 
            { 
                return null; 
            }

            studentEntity.StudentNumber = updateStudentDto.StudentNumber;
            studentEntity.Surname = updateStudentDto.Surname;
            studentEntity.CellNumber = updateStudentDto.CellNumber;
            studentEntity.Name = updateStudentDto.Name;
            
            await _dataContext.SaveChangesAsync();
            return studentEntity;
        }
    }
}
