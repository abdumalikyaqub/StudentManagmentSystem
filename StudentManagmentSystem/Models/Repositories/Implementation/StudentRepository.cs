﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.Repositories.Interfaces;
using System.Numerics;

namespace StudentManagmentSystem.Models.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
        }

        public async Task<List<Student>> GetStudentBySecondName(string? secondname)
        {
            var student = await _context.Students
                .Where(m => m.SecondName.ToLower() == secondname.ToLower()).ToListAsync();

            return student;
            //return await _context.Students.FirstOrDefaultAsync(e => e.StudentId == id);
        }
        public async Task<Student> StudentById(int? id)
        {
           
            return await _context.Students
                .Include(s => s.Educations)
                .Include(s => s.Dactyloscopies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Student>> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.Country)
                .Include(s => s.Dactyloscopies)
                .Include(s => s.Educations)
                .ToListAsync();

            return students;
            //return await (Task<List<Student>>)_context.Students.ToListAsync();
        }

        public async Task<bool> IsStudentById(int id)
        {
            return await _context.Students.AnyAsync(e => e.Id == id);
        }

        public async Task UpdateStudent(Student student)
        {
            var student_info = await _context.Students
                .Include(s => s.Country)
                .Include(s => s.Educations)
                .Include(s => s.Dactyloscopies)
                .FirstOrDefaultAsync(e => e.Id == student.Id);

            if (student_info != null)
            {
                //student_info.Id = student.Id;
                //student_info.StudentId = student.Id;
                student_info.FirstName = student.FirstName;
                student_info.LastName = student.LastName;
                student_info.CountryId = student.CountryId;
                student_info.Dactyloscopies[0].Id = student.Dactyloscopies[0].Id;
                student_info.Dactyloscopies[0].StudentId = student.Dactyloscopies[0].StudentId;
                student_info.Dactyloscopies[0].Status = student.Dactyloscopies[0].Status;
                student_info.Educations[0].Id = student.Educations[0].Id;
                student_info.Educations[0].StudentId = student.Educations[0].StudentId;
                student_info.Educations[0].EducationFormId = student.Educations[0].EducationFormId;
                student_info.Educations[0].InstituteId = student.Educations[0].InstituteId;

                await _context.SaveChangesAsync();

            }
            //_context.Entry(student).State = EntityState.Modified;
            //_context.Students.Update(student);
            //_context.Update(student);
            // Обновление данных студента
            //_context.Update(student);

            // Обновление данных Education
            //foreach (var education in student.Educations)
            //{
            //    _context.Update(education);
            //}

            //// Обновление данных Dactyloscopies
            //foreach (var dactyloscopy in student.Dactyloscopies)
            //{
            //    _context.Update(dactyloscopy);
            //}

            await _context.SaveChangesAsync();
        }
        public List<SelectListItem> GetCountries()
        {
            // Получить список стран из базы данных
            var countries = _context.Countries.ToList();

            // Преобразовать список стран в SelectListItem
            var countryItems = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            }).ToList();

            return countryItems;
        }
    }
}
