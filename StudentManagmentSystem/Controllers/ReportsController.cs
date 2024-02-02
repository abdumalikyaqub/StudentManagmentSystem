using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models.Repositories.Interfaces;
using iTextSharp.text;
using System;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagmentSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;
        private IStudentRepository _studentRepository;

        // Устанавливаем шрифт с поддержкой кириллицы (Arial Unicode MS, например)
        public BaseFont? baseFont = BaseFont.CreateFont($"{Directory.GetCurrentDirectory()}\\wwwroot\\font\\Roboto-Medium.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        public ReportsController(IStudentRepository studentRepository, IEducationRepository educationRepository, IDactyloscopyRepository dactyloscopyRepository, ICountryRepository countryRepository, ILogger<StudentsController> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            return View();
        }

        public async Task<IActionResult> DactyloscopiesPdfReport()
        {
            var students = await _studentRepository.GetStudents();

            using (var stream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                var font = new iTextSharp.text.Font(baseFont, 12);

                var table = new PdfPTable(4);
                table.AddCell(new PdfPCell(new Phrase("ФИО", font)));
                table.AddCell(new PdfPCell(new Phrase("Группа", font)));
                table.AddCell(new PdfPCell(new Phrase("Дата прохождения", font)));
                table.AddCell(new PdfPCell(new Phrase("Статус", font)));

                foreach (var student in students)
                {
                    string fullname = $"{student.FirstName} {student.SecondName} {student.LastName}";
                    table.AddCell(new PdfPCell(new Phrase(fullname, font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Educations[0].GroupName ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Dactyloscopies[0].DateOfPassage ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Dactyloscopies[0].Status ?? "н/д", font)));
                }


                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                Response.Headers["Content-Disposition"] = "inline; filename=dactyloscopies.pdf";
                return File(content, "application/pdf", "dactyloscopies.pdf");
            }

            //// Создаем новый документ PDF
            //PdfDocument document = new PdfDocument();
            //PdfPage page = document.AddPage();
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            //XFont font = new XFont("Arial", 12);

            //// Создаем заголовки таблицы
            //string[] headers = { "ФИО", "Группа", "Дата прохождения", "Статус" };
            //double xPosition = 10;
            //double yPosition = 10;
            //double cellWidth = 80;
            //double cellHeight = 30;

            //foreach (var header in headers)
            //{
            //    gfx.DrawString(header, font, XBrushes.Black, xPosition, yPosition);
            //    xPosition += cellWidth;
            //}

            //yPosition += cellHeight;

            //// Заполняем таблицу данными
            //foreach (var data in dactyloscopyData)
            //{
            //    xPosition = 10;
            //    string fullname = $"{data.FirstName} {data.SecondName} {data.LastName}";
            //    gfx.DrawString(fullname, font, XBrushes.Black, xPosition, yPosition);
            //    xPosition += cellWidth;

            //    gfx.DrawString(data.Educations[0].GroupName ?? "н/д", font, XBrushes.Black, xPosition, yPosition);
            //    xPosition += cellWidth;

            //    gfx.DrawString(data.Dactyloscopies[0].DateOfPassage ?? "н/д", font, XBrushes.Black, xPosition, yPosition);
            //    xPosition += cellWidth;

            //    gfx.DrawString(data.Dactyloscopies[0].Status ?? "н/д", font, XBrushes.Black, xPosition, yPosition);
            //    xPosition += cellWidth;

            //    yPosition += cellHeight;
            //}


            //string filePath = Path.Combine(Path.GetTempPath(), "dactyloscopy.pdf");
            //document.Save(filePath);
            //document.Dispose();

            //byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //return File(fileBytes, "application/pdf", "dactyloscopy.pdf");

        }

        public async Task<IActionResult> ZaochnikiPdfReport()
        {
            var students_info = await _studentRepository.GetStudents();
            var students = students_info.Where(s => s.Educations.Any(e => e.EducationFormId.Value == Models.Enums.EducationForm.Заочная));
            
            using (var stream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                var font = new iTextSharp.text.Font(baseFont, 12);

                var table = new PdfPTable(3);
                table.AddCell(new PdfPCell(new Phrase("ФИО", font)));
                table.AddCell(new PdfPCell(new Phrase("Образование", font)));
                table.AddCell(new PdfPCell(new Phrase("Страна", font)));

                foreach (var student in students)
                {
                    string fullname = $"{student.FirstName} {student.SecondName} {student.LastName}";
                    string education = $"{student.Educations[0].InstituteId}, {student.Educations[0].SpecialityId}, {student.Educations[0].GroupName ?? " " }, {student.Educations[0].KursLevel ?? " "}";
                    table.AddCell(new PdfPCell(new Phrase(fullname, font)));
                    table.AddCell(new PdfPCell(new Phrase(education ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Country.Title ?? "н/д", font)));
                }


                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                Response.Headers["Content-Disposition"] = "inline; filename=zaochniki.pdf";
                return File(content, "application/pdf", "zaochniki.pdf");
            }

        }

        public async Task<IActionResult> AcademiyaPdfReport()
        {

            var students_info = await _studentRepository.GetStudents();
            var students = students_info.Where(s => s.Educations.Any(e => e.StatusId.Value == Models.Enums.EducationStatus.Академия));

            using (var stream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                var font = new iTextSharp.text.Font(baseFont, 12);

                var table = new PdfPTable(4);
                table.AddCell(new PdfPCell(new Phrase("ФИО", font)));
                table.AddCell(new PdfPCell(new Phrase("Образование", font)));
                table.AddCell(new PdfPCell(new Phrase("Страна", font)));
                table.AddCell(new PdfPCell(new Phrase("Приказ", font)));

                foreach (var student in students)
                {
                    string fullname = $"{student.FirstName} {student.SecondName} {student.LastName}";
                    string education = $"{student.Educations[0].InstituteId} ,  {student.Educations[0].SpecialityId}, {student.Educations[0].GroupName ?? " "}, {student.Educations[0].KursLevel ?? " "}";
                    table.AddCell(new PdfPCell(new Phrase(fullname, font)));
                    table.AddCell(new PdfPCell(new Phrase(education ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Country.Title ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Orders[0].Number ?? "н/д", font)));
                }


                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                Response.Headers["Content-Disposition"] = "inline; filename=akademiya.pdf";
                return File(content, "application/pdf", "akademiya.pdf");
            }

        }

        public async Task<IActionResult> GraduatePdfReport()
        {

            var students_info = await _studentRepository.GetStudents();
            var students = students_info.Where(s => s.Educations.Any(e => e.StatusId.Value == Models.Enums.EducationStatus.Завершевший));

            using (var stream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                var font = new iTextSharp.text.Font(baseFont, 12);

                var table = new PdfPTable(4);
                table.AddCell(new PdfPCell(new Phrase("ФИО", font)));
                table.AddCell(new PdfPCell(new Phrase("Образование", font)));
                table.AddCell(new PdfPCell(new Phrase("Страна", font)));
                table.AddCell(new PdfPCell(new Phrase("Приказ", font)));

                foreach (var student in students)
                {
                    string fullname = $"{student.FirstName} {student.SecondName} {student.LastName}";
                    string education = $"{student.Educations[0].InstituteId} ,  {student.Educations[0].SpecialityId}, {student.Educations[0].GroupName ?? " "}, {student.Educations[0].KursLevel ?? " "}";
                    table.AddCell(new PdfPCell(new Phrase(fullname, font)));
                    table.AddCell(new PdfPCell(new Phrase(education ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Country.Title ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Orders[0].Number ?? "н/д", font)));
                }


                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                Response.Headers["Content-Disposition"] = "inline; filename=graduate.pdf";
                return File(content, "application/pdf", "graduate.pdf");
            }

        }

        public async Task<IActionResult> PassportPdfReport()
        {
            var students_info = await _studentRepository.GetStudents();
            var students = students_info.Where(s => s.DocumentId.Value == Models.Enums.DocumentStatus.Гражданство_РФ);

            using (var stream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                var font = new iTextSharp.text.Font(baseFont, 12);

                var table = new PdfPTable(4);
                table.AddCell(new PdfPCell(new Phrase("ФИО", font)));
                table.AddCell(new PdfPCell(new Phrase("Образование", font)));
                table.AddCell(new PdfPCell(new Phrase("Страна", font)));
                table.AddCell(new PdfPCell(new Phrase("Паспортные данные", font)));

                foreach (var student in students)
                {
                    string fullname = $"{student.FirstName} {student.SecondName} {student.LastName}";
                    string education = $"{student.Educations[0].InstituteId} ,  {student.Educations[0].SpecialityId} ,  {student.Educations[0].GroupName ?? " "}, {student.Educations[0].KursLevel ?? " " }";
                    table.AddCell(new PdfPCell(new Phrase(fullname, font)));
                    table.AddCell(new PdfPCell(new Phrase(education ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.Country.Title ?? "н/д", font)));
                    table.AddCell(new PdfPCell(new Phrase(student.PassportData ?? "н/д", font)));
                }


                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                Response.Headers["Content-Disposition"] = "inline; filename=passport.pdf";
                return File(content, "application/pdf", "passport.pdf");
            }

        }
    }
}
