using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public int? CountryId { get; set; }
        public Gender? Gender { get; set; }
        public string? Birthday { get; set; }
        public string? PassportData { get; set; }
        public string? FamilyStatus { get; set; }
        public int? DocumentId { get; set; }

        public Country? Country { get; set; }
        public List<Dactyloscopy> Dactyloscopies { get; set; }
        public List<Education> Educations { get; set; }
    }

    public enum Gender
    {
        Муж = 1,
        Жен = 2
    }
}
