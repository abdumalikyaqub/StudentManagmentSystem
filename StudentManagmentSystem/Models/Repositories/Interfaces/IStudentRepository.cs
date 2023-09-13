using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<Student> GetStudentById(int id);
        Task<bool> IsStudentById(int id);
        Task UpdateStudent(Student student);
        Task DeleteStudentById(int id);
    }
}
