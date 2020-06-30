using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface ITeacherDbService
    {
        Task<SubjectTeachersDb> GetSubjectTeachers(string subjectId);

        Task SaveSubjectTeachers(SubjectTeachersDb subjectTeachers);
    }
}
