using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetStudents();

            var studentDetails = new List<StudentDetailsViewModel>();

            foreach (var student in students)
            {
                var dactylos = await _dactyloscopyRepository.GetById(student.StudentId);
                var education = await _educationRepository.GetById(student.StudentId);
               
                var studentDetail = new StudentDetailsViewModel 
                {
                    Student = student,
                    Education = education,
                    Dactyloscopy = dactylos
                };
                studentDetails.Add(studentDetail);
            }

            return View(studentDetails);
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
            return RedirectToAction(nameof(Edit), new { id = studentDetails.Student.StudentId });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            var dactylos = await _dactyloscopyRepository.GetById(id);
            var education = await _educationRepository.GetById(id);

            var studentDetails = new StudentDetailsViewModel
            {
                Student = student,
                Dactyloscopy = dactylos,
                Education = education
            };

            if (studentDetails == null)
            {
                return NotFound();
            }
            return View(studentDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentDetailsViewModel studentDetails)
        {
            
            if (ModelState.IsValid)
            {
                // Проверьте, существует ли студент в базе данных
                //var existingStudent = await _studentRepository.GetStudentById(studentDetails.Student.StudentId);
                //if (existingStudent == null)
                //{
                //    return NotFound();
                //}

                //// Проверьте, существует ли Dactyloscopy в базе данных
                //var existingDactyloscopy = await _dactyloscopyRepository.GetById(studentDetails.Dactyloscopy.StudentId);
                //if (existingDactyloscopy == null)
                //{
                //    return NotFound();
                //}

                //// Проверьте, существует ли Education в базе данных
                //var existingEducation = await _educationRepository.GetById(studentDetails.Education.StudentId);
                //if (existingEducation == null)
                //{
                //    return NotFound();
                //}

                await _studentRepository.UpdateStudent(studentDetails.Student);
                //await _dactyloscopyRepository.UpdateDactylos(studentDetails.Dactyloscopy);
                //await _educationRepository.UpdateEducation(studentDetails.Education);
                return RedirectToAction("Index");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                var errorMessage = error.ErrorMessage;
                ViewBag.ErrorMess = errorMessage;
            }

            return View(studentDetails);
        }
    }
}
