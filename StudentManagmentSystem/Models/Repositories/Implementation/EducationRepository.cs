using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;

namespace StudentManagmentSystem.Models.Repositories.Implementation
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _context;
        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEducation(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAll()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetById(int id)
        {
            return await _context.Educations.FindAsync(id);
        }
    }
}
