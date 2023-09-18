using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.Entities
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
       // public int EducationId { get; set; }
        public int? StudentId { get; set; }
        public int? EducationFormId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? EducationBasisId { get; set; }
        public string? Status { get; set; }
        public int? InstituteId { get; set; }
        public Student? Student { get; set; }
    }
}
