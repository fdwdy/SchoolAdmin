using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Mapping
{
    public class AutoMapperBusinessProfile : Profile
    {
        public AutoMapperBusinessProfile()
        {
            CreateMap<EmployeeDb, EmployeeDTO>()
                .ForMember("FullName", opt => opt.MapFrom(c => c.Name + ' ' + c.Middlename + ' ' + c.Surname)).ReverseMap();
            CreateMap<EmployeeDb, Employee>().ReverseMap();
            CreateMap<SubjectDb, Subject>().ReverseMap();
            CreateMap<SubjectTeachersDb, SubjectTeachers>().ReverseMap();
        }
    }
}