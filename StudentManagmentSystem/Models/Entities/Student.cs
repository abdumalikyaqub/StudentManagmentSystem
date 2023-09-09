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
        public string? Birthday { get; set; }
        public string? PassportData { get; set; }
        public int? EducationId { get; set; }
        public int? RegistrationId { get; set; }
        public string? FamilyStatus { get; set; }
        public int? DocumentId { get; set; }
        public int? DactyloscopyId { get; set; }
        public int? OrderId { get; set; }
    }
}
