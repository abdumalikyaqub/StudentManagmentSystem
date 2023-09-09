using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetStudentById(int id);
        void UpdateStudent(Student student);
        void DeleteStudentById(int id);
    }
}
