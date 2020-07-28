using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface ISubjectService : ICommonService<Subject>, IDisposable
    {
        Task<bool> FindByName(string name);

        Task<IEnumerable<SubjectStatistics>> GetAllWithEmployeesSorted();

        Task<SubjectStatistics> GetByNameWithEmployeesSorted(string name);
    }
}
