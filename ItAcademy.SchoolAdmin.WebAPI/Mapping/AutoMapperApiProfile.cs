using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItAcademy.SchoolAdmin.WebAPI.Mapping
{
    public class AutoMapperApiProfile : Profile
    {
        public AutoMapperApiProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Subject, SubjectModel>().ReverseMap();
            CreateMap<Position, PositionModel>().ReverseMap();
            CreateMap<PositionStatistics, PositionModel>().ReverseMap();
            CreateMap<EmployeePositionStatistics, EmployeePositionStatisticsModel>()
                .ForMember(
                    elm => elm.Phones,
                    opt => opt.MapFrom(e => GetStringNumbers(e)))
                .ForMember(
                    elm => elm.Subjects,
                    opt => opt.MapFrom(e => GetStringSubjects(e)));
            CreateMap<SubjectStatistics, SubjectModel>().ReverseMap();
            CreateMap<EmployeeSubjectStatistics, EmployeeSubjectStatisticsModel>()
                .ForMember(
                    elm => elm.Phones,
                    opt => opt.MapFrom(e => GetStringNumbers(e)));
            CreateMap<Phone, PhoneModel>().ReverseMap();
        }

        private static IEnumerable<string> GetStringNumbers(EmployeeItemBase e)
        {
            return e.Phones.Select(cp => cp.Number);
        }

        private static IEnumerable<string> GetStringSubjects(EmployeePositionStatistics e)
        {
            return e.Subjects.Select(cp => cp.Name);
        }
    }
}