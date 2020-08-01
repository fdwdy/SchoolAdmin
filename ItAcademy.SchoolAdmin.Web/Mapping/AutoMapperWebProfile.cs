using System.Collections.Generic;
using System.Linq;
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
            CreateMap<Employee, EmployeeContactsModel>().ReverseMap();
            CreateMap<Employee, CreateEmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeListModel>()
                .ForMember(
                    elm => elm.FullName,
                    opt => opt.MapFrom(e => $"{e.Name} {e.Middlename} {e.Surname}".Replace("  ", " ")))
                .ForMember(
                e => e.Phones,
                m => m.MapFrom(p => GetStringNumbers(p)));
            CreateMap<Subject, SubjectViewModel>().ReverseMap();
            CreateMap<Position, PositionViewModel>().ReverseMap();
            CreateMap<Worker, WorkerViewModel>().ReverseMap();
            CreateMap<Phone, PhoneViewModel>().ReverseMap();
        }

        private static IEnumerable<string> GetStringNumbers(Employee e)
        {
            return e.Phones.Select(cp => cp.Number);
        }
    }
}