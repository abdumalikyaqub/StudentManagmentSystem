using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;

namespace StudentManagmentSystem.Models.Repositories.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Admin> GetAdmin(string? email, string? pass)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == email && a.Password == pass);

            return admin;
        }
    }
}
