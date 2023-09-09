using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Dactyloscopy> Dactyloscopies { get; set; }
        public DbSet<Education> Educations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            bool isAvalaible = Database.CanConnect();
            // bool isAvalaible2 = await db.Database.CanConnectAsync();
            if (isAvalaible) Console.WriteLine("База данных доступна");
            else Console.WriteLine("База данных не доступна");
        }
    }
}
