using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;

namespace StudentManagmentSystem.Models.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await (Task<Student>)_context.Students.Where(e => e.StudentId == id);
        }

        public async Task<bool> IsStudentById(int id)
        {
            return await _context.Students.AnyAsync(e => e.StudentId == id);
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
