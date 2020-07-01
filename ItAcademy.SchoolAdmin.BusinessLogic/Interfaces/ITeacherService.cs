using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface ITeacherService
    {
        Task<SubjectTeachers> GetSubjectTeachers(string subjectId);

        Task SaveSubjectTeachers(string subjectId, string[] subjectEmployeeIds);
    }
}
