using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;
using StudentManagmentSystem.Models.ViewModels;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        private IEducationRepository _educationRepository;
        private IDactyloscopyRepository _dactyloscopyRepository;
        public StudentController(IStudentRepository studentRepository, IEducationRepository educationRepository, IDactyloscopyRepository dactyloscopyRepository)
        {
            _studentRepository = studentRepository;
            _educationRepository = educationRepository;
            _dactyloscopyRepository = dactyloscopyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentDetailsViewModel studentDetails)
        {
            _studentRepository.AddStudent(studentDetails.Student);
            _educationRepository.AddEducation(studentDetails.Education);
            _dactyloscopyRepository.AddDactyloscopy(studentDetails.Dactyloscopy);
            return RedirectToAction(nameof(Index));
        }
    }
}
