using AutoMapper;
using StudentManagmentSystem.Models.Entities;
using StudentManagmentSystem.Models.ViewModels;

namespace StudentManagmentSystem.Models
{
    public class AppMappingProfile: Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Student, StudentEditViewModel>().ReverseMap();
        }
    }
}
