using AutoMapper;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
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

        public async Task<IActionResult> Index(string sortOrder)
        {

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.CountrySortParam = sortOrder == "Country" ? "country_desc" : "Country";
            //ViewBag.InstituteSortParam = sortOrder == "Institute" ? "institute_desc" : "Institute";

            var students = await _studentRepository.GetStudents();

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderBy(s => s.StudentId).ToList();
                    //students.Sort();
                    break;
                //case "Country":
                //    students = (List<Student>)students.OrderBy(s => s.Country.Title);
                //    break;
                //case "country_desc":
                //    students = (List<Student>)students.OrderByDescending(s => s.Country.Title);
                //    break;
                //case "Institute":
                //    students = students.OrderBy(s => s.Educations.Find(e => e.InstituteId));
                //    break;
                //case "institute_desc":
                //    students = students.OrderByDescending(s => s.Education.Institute);
                //    break;
                default:
                    students = students.OrderBy(s => s.FirstName).ToList();
                    
                    //students.Sort();
                    break;
            }

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

        public async  Task<ActionResult> Search(int? studentId)
        {
            if (studentId == null)
            {
                // Возвращайте представление для поиска, если параметр studentId не указан
                return View();
            }

            var student = await _studentRepository.StudentById(studentId);

            if (student == null)
            {
                // Возвращайте представление с сообщением, если студент не найден
                ViewBag.Message = "Студент не найден.";
                return View();
            }

            return View(student);
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

        public async Task<IActionResult> Reports()
        {
            return View();
        }

        public async Task<IActionResult> GeneratePdfReport()
        {
            var students = await _studentRepository.GetStudents();

            using (var stream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                // Добавьте содержимое PDF-отчета, например, таблицу со списком студентов
                var table = new PdfPTable(2);
                table.AddCell("Id");
                table.AddCell("Имя");

                foreach (var student in students)
                {
                    table.AddCell(student.StudentId.ToString());
                    table.AddCell(student.FirstName);
                }

                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                Response.Headers["Content-Disposition"] = "inline; filename=StudentReport.pdf";
                return File(content, "application/pdf", "StudentReport.pdf");
            }
        }


    }
}
