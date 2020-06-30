using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;

        private readonly ITeacherDbService _tchService;

        public TeacherService(IMapper mapper, ITeacherDbService tchService)
        {
            _tchService = tchService;
            _mapper = mapper;
        }

        public async Task<SubjectTeachers> GetSubjectTeachers(string subjectId)
        {
            return _mapper.Map<SubjectTeachers>(await _tchService.GetSubjectTeachers(subjectId));
        }

        public async Task SaveSubjectTeachers(SubjectTeachers subjectTeachers)
        {
            await _tchService.SaveSubjectTeachers(_mapper.Map<SubjectTeachersDb>(subjectTeachers));
        }
    }
}
