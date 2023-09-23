using StudentManagmentSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.Entities
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
       // public int EducationId { get; set; }
        public int? StudentId { get; set; }
        public string? EntryYear { get; set; }
        public string? GroupName { get; set; }
        public EducationForm? EducationFormId { get; set; }
        public EducationLevel? EducationLevelId { get; set; }
        public EducationBasis? EducationBasisId { get; set; }
        public EducationStatus? StatusId { get; set; }
        public int? InstituteId { get; set; }
        public int? SpecializationId { get; set; }
        public int? SpecialityId { get; set; }


        public Student? Student { get; set; }
        public Institute? Institute { get; set; }
        public Speciality? Speciality { get; set; }
        public Specialization? Specialization { get; set; }
    }
}
