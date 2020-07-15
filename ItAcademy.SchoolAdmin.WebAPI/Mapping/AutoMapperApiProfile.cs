using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.WebAPI.Models;

namespace ItAcademy.SchoolAdmin.WebAPI.Mapping
{
    public class AutoMapperApiProfile : Profile
    {
        public AutoMapperApiProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Subject, SubjectModel>().ReverseMap();
            CreateMap<Position, PositionModel>().ReverseMap();
            CreateMap<Phone, PhoneModel>().ReverseMap();
        }
    }
}