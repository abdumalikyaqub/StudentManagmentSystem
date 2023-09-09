using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IDactyloscopyRepository
    {
        List<Dactyloscopy> GetAll();
        Dactyloscopy GetById(int id);
        void AddDactyloscopy(Dactyloscopy dactyloscopy);
    }
}
