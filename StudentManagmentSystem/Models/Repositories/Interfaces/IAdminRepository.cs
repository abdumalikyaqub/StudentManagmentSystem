using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> GetAdmin(string? email, string? pass);
    }
}
