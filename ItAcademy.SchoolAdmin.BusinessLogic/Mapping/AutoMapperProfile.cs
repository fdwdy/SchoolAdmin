using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDb, EmployeeDTO>()
                .ForMember("FullName", opt => opt.MapFrom(c => c.Name + ' ' + c.Middlename + ' ' + c.Surname)).ReverseMap();
            CreateMap<EmployeeDb, Employee>().ReverseMap();
        }
    }
}