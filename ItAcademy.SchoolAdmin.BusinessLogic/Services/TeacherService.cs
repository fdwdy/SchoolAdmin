using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    /// <summary>
    /// Нужен ли IDisposable?.
    /// </summary>
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

        public async Task SaveSubjectTeachers(string subjectId, string[] subjectEmployeeIds)
        {
            await _tchService.SaveSubjectTeachers(subjectId, subjectEmployeeIds);
        }
    }
}
