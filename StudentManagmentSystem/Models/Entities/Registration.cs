using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models.Entities
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
       // public int RegistrationId { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string DistrictName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public int RoomNumber { get; set; }
    }
}
