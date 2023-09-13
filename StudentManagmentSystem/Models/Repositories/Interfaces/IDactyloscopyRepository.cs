using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IDactyloscopyRepository
    {
        Task<List<Dactyloscopy>> GetAll();
        Task<Dactyloscopy> GetById(int id);
        Task AddDactyloscopy(Dactyloscopy dactyloscopy);
    }
}
