﻿using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.Entities
{
    public class Dactyloscopy
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? Status { get; set; }
        public string? DateOfPassage { get; set; }
        public Student? Student { get; set; }
    }
}
