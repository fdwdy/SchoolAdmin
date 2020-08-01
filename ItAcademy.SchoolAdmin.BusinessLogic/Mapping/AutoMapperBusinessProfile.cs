using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Mapping
{
    public class AutoMapperBusinessProfile : Profile
    {
        public AutoMapperBusinessProfile()
        {
            CreateMap<EmployeeDb, Employee>().ReverseMap();
            CreateMap<MessageDb, Message>().ReverseMap();
            CreateMap<SubjectDb, Subject>().ReverseMap();
            CreateMap<SubjectTeachersDb, SubjectTeachers>().ReverseMap();
            CreateMap<PositionDb, Position>().ReverseMap();
            CreateMap<WorkerDb, Worker>().ReverseMap();
            CreateMap<PhoneDb, Phone>().ReverseMap();
            CreateMap<SubjectDbStatistics, SubjectStatistics>().ReverseMap();
            CreateMap<EmployeeDbSubjectStatistics, EmployeeSubjectStatistics>().ReverseMap();
            CreateMap<PositionDbStatistics, PositionStatistics>().ReverseMap();
            CreateMap<EmployeeDbPositionStatistics, EmployeePositionStatistics>().ReverseMap();
        }
    }
}