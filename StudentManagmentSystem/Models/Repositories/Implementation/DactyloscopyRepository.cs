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

        public void AddDactyloscopy(Dactyloscopy dactyloscopy)
        {
            _context.Dactyloscopies.Add(dactyloscopy);
            _context.SaveChanges();
        }

        public List<Dactyloscopy> GetAll()
        {
            return _context.Dactyloscopies.ToList();
        }

        public Dactyloscopy GetById(int id)
        {
            return _context.Dactyloscopies.Find(id);
        }
    }
}
