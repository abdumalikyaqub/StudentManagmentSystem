using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;

namespace StudentManagmentSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        private IStudentRepository _studentRepository;
        private IEducationRepository _educationRepository;
        private IDactyloscopyRepository _dactyloscopyRepository;
        private ICountryRepository _countryRepository;

        public StudentsController(IStudentRepository studentRepository, IEducationRepository educationRepository, IDactyloscopyRepository dactyloscopyRepository, ICountryRepository countryRepository, ILogger<StudentsController> logger)
        {
            _studentRepository = studentRepository;
            _educationRepository = educationRepository;
            _dactyloscopyRepository = dactyloscopyRepository;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index(string sortOrder)
        {

            ViewBag.SecondNameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParam = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.InstituteSortParam = sortOrder == "Institute" ? "institute_desc" : "Institute";

            var students = await _studentRepository.GetStudents();

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderBy(s => s.SecondName).ToList();
                    break;
                case "Country":
                    students = students.OrderBy(s => s.Country.Title).ToList();
                    break;
                case "country_desc":
                    students = students.OrderByDescending(s => s.Country.Title).ToList();
                    break;
                case "Institute":
                    students = students.OrderBy(s => s.Educations[0].InstituteId).ToList();
                    break;
                case "institute_desc":
                    students = students.OrderByDescending(s => s.Educations[0].InstituteId).ToList();
                    break;
                default:
                    students = students.OrderBy(s => s.FirstName).ToList();
                    break;
            }

            return View(students);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewBag.CountryList = _studentRepository.GetCountries();
            ViewBag.InstituteList = _studentRepository.GetInstitutes();
            ViewBag.SpecialityList = _studentRepository.GetSpecialities();
            ViewBag.SpecializationList = _studentRepository.GetSpecializations();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            //if (ModelState.IsValid)
            //{
            if (student != null)
            {
                await _studentRepository.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
                //return RedirectToAction(nameof(Edit), new { id = student.Id });
            //}

            var countries = await _countryRepository.GetCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Title");
            ViewBag.InstituteList = _studentRepository.GetInstitutes();
            ViewBag.SpecialityList = _studentRepository.GetSpecialities();
            ViewBag.SpecializationList = _studentRepository.GetSpecializations();

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

            //var countries = await _countryRepository.GetCountries();
            ViewBag.CountryList = _studentRepository.GetCountries();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {

            if (id != student.Id)
            {
                return NotFound();
            }

            if (student != null)
            {
                await _studentRepository.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }

            var countries = await _countryRepository.GetCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Title");
            return View(student);
        }

        [Authorize]
        public async Task<ActionResult> Search(string? secondname)
        {
            if (secondname == null)
            {
                return View();
            }

            var students = await _studentRepository.GetStudentBySecondName(secondname);

            if (students == null)
            {
                ViewBag.Message = "Студент не найден.";
                return View();
            }

            return View(students);
        }

        public async Task<ActionResult> Details(int id)
        {
            var studentDetails = await _studentRepository.StudentById(id);
            if (studentDetails == null)
            {
                return NotFound();
            }
            return View(studentDetails);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var studentDetails = await _studentRepository.StudentById(id);
            if (studentDetails == null)
            {
                return NotFound();
            }
            return View(studentDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var studentDetails = await _studentRepository.StudentById(id);
            if (studentDetails != null)
            {
                await _studentRepository.DeleteStudentById(id);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDetails);
        }

        //public async Task<IActionResult> Reports()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> GeneratePdfReport()
        //{
        //    var students = await _studentRepository.GetStudents();

        //    using (var stream = new MemoryStream())
        //    {
        //        var document = new iTextSharp.text.Document();
        //        PdfWriter.GetInstance(document, stream);
        //        document.Open();

        //        var table = new PdfPTable(2);
        //        table.AddCell("Id");
        //        table.AddCell("Имя");

        //        foreach (var student in students)
        //        {
        //            table.AddCell(student.Id.ToString());
        //            table.AddCell(student.FirstName);
        //        }

        //        document.Add(table);
        //        document.Close();

        //        var content = stream.ToArray();
        //        Response.Headers["Content-Disposition"] = "inline; filename=StudentReport.pdf";
        //        return File(content, "application/pdf", "StudentReport.pdf");
        //    }
        //}


    }
}
