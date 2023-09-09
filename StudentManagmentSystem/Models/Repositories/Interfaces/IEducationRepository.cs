using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        void AddEducation(Education education);
        List<Education> GetAll();
        Education GetById(int id);
    }
}
