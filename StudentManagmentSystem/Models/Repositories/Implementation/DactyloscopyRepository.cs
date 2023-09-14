using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;

namespace StudentManagmentSystem.Models.Repositories.Implementation
{
    public class DactyloscopyRepository : IDactyloscopyRepository
    {
        private readonly ApplicationDbContext _context;
        public DactyloscopyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDactyloscopy(Dactyloscopy dactyloscopy)
        {
            _context.Dactyloscopies.Add(dactyloscopy);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dactyloscopy>> GetAll()
        {
            return await _context.Dactyloscopies.ToListAsync();
        }

        public async Task<Dactyloscopy> GetById(int? id)
        {
            return await _context.Dactyloscopies.FirstOrDefaultAsync(e => e.StudentId == id);
        }

        public async Task UpdateDactylos(Dactyloscopy dactyloscopy)
        {
            //_context.Dactyloscopies.Update(dactyloscopy);
            _context.Entry(dactyloscopy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
