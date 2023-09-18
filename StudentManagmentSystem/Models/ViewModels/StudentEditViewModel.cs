using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.ViewModels
{
    public class StudentEditViewModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Выберите страну")]
        public int CountryId { get; set; }

        public List<SelectListItem> Countries { get; set; }

        // Добавляем информацию о Dactyloscopy и Education
        public string DactyloscopyStatus { get; set; }

        public int InstituteId { get; set; }
    }
}
