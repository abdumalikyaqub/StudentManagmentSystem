using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? Number { get; set; }
        public string? Title { get; set; }
    }
}
