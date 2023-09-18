using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IEducationRepository educationRepository, IDactyloscopyRepository dactyloscopyRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _educationRepository = educationRepository;
            _dactyloscopyRepository = dactyloscopyRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetStudents();

            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            //var countries = await _countryRepository.GetCountries();
            //ViewBag.CountryList = new SelectList(countries, "Id", "Title");
            ViewBag.CountryList = _studentRepository.GetCountries();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var rand = new Random();
                bool t = true;
                while (t)
                {
                    int studentId = rand.Next(1000, 9999);
                    bool is_student = await _studentRepository.IsStudentById(studentId);
                    if (!is_student)
                    {
                        student.StudentId = studentId;
                        //education.StudentId = studentId;
                        //dactyloscopy.StudentId = studentId;
                        t = false;
                    }
                }

                await _studentRepository.AddStudent(student);
                //await _educationRepository.AddEducation(education);
                //await _dactyloscopyRepository.AddDactyloscopy(dactyloscopy);
                

                return RedirectToAction(nameof(Edit), new { id = student.StudentId });
            }

            var countries = await _countryRepository.GetCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Title");

            return View(student);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepository.StudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            var countries = await _countryRepository.GetCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Title");
            //var viewModel = _mapper.Map<StudentEditViewModel>(student);
            //var countries = _studentRepository.GetCountries();
            //viewModel.Countries = countries;

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {

            //if (id != viewModel.StudentId)
            //{
            //    return BadRequest();
            //}

            //if (ModelState.IsValid)
            //{
            //    var student = _mapper.Map<Student>(viewModel);
            //    await _studentRepository.UpdateStudent(student);
            //    return RedirectToAction("Index");
            //}

            //var countries = _studentRepository.GetCountries();
            //viewModel.Countries = countries;
            //return View(viewModel);

            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                    await _studentRepository.UpdateStudent(student);
                    // await _dactyloscopyRepository.UpdateDactylos(dactyloscopy);
                    // await _educationRepository.UpdateEducation(education);

                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    bool is_student = await _studentRepository.IsStudentById((int)student.StudentId);
                //    if (!is_student)
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }

            //foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            //{
            //    var errorMessage = error.ErrorMessage;
            //    ViewBag.ErrorMess = errorMessage;
            //}

            var countries = await _countryRepository.GetCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Title");

            return View(student);
        }
       
    }
}
