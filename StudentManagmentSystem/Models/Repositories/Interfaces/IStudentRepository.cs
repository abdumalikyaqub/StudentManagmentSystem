using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<List<Student>> GetStudentBySecondName(string? secondname);
        Task<Student> StudentById(int? id);
        Task<List<Student>> GetStudents();
        List<SelectListItem> GetCountries();
        Task<bool> IsStudentById(int id);
        Task UpdateStudent(Student student);
        Task DeleteStudentById(int id);
    }
}
