using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
    }
}
