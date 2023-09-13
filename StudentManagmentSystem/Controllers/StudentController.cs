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
        public async Task<IActionResult> Create(StudentDetailsViewModel studentDetails)
        {
            var rand = new Random();
            bool t = true;
            while (t)
            {
                int studentId = rand.Next(1000, 9999);
                bool student = await _studentRepository.IsStudentById(studentId);
                if (!student)
                {
                    studentDetails.Student.StudentId = studentId;
                    studentDetails.Education.StudentId = studentId;
                    studentDetails.Dactyloscopy.StudentId = studentId;
                    t = false;
                }
            }
            await _educationRepository.AddEducation(studentDetails.Education);
            await _dactyloscopyRepository.AddDactyloscopy(studentDetails.Dactyloscopy);
            await _studentRepository.AddStudent(studentDetails.Student);
            return RedirectToAction(nameof(Index));
        }
    }
}
