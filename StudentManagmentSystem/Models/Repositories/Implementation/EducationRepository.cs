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
        public void AddEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
        }

        public List<Education> GetAll()
        {
            return _context.Educations.ToList();
        }

        public Education GetById(int id)
        {
            return _context.Educations.Find(id);
        }
    }
}
