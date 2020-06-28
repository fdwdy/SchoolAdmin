using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Mapping
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeEditModel>().ReverseMap();
            CreateMap<Employee, EmployeeSelectViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeListModel>()
                .ForMember(
                    elm => elm.FullName,
                    opt => opt.MapFrom(e => $"{e.Name} {e.Middlename} {e.Surname}".Replace("  ", " ")));
            CreateMap<Subject, SubjectViewModel>().ReverseMap();
            CreateMap<Subject, SubjectEditEmployeeViewModel>().ReverseMap();
        }
    }
}