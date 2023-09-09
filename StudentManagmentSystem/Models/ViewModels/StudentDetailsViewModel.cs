using StudentManagmentSystem.Models.Entities;

namespace StudentManagmentSystem.Models.ViewModels
{
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }
        public Education Education { get; set; }
        public Order Order { get; set; }
        public Registration Registration { get; set; }
        public Dactyloscopy Dactyloscopy { get; set; }
    }
}
