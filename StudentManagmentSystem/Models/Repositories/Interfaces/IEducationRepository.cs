using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        Task AddEducation(Education education);
        Task UpdateEducation(Education education);
        Task<List<Education>> GetAll();
        Task<Education> GetById(int? id);
    }
}
