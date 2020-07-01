using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Mapping
{
    public class AutoMapperBusinessProfile : Profile
    {
        public AutoMapperBusinessProfile()
        {
            CreateMap<EmployeeDb, Employee>().ReverseMap();
            CreateMap<SubjectDb, Subject>().ReverseMap();
            CreateMap<SubjectTeachersDb, SubjectTeachers>().ReverseMap();
            CreateMap<PositionDb, Position>().ReverseMap();
            CreateMap<WorkerDb, Worker>().ReverseMap();
        }
    }
}