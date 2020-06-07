using System;
using System.Collections.Generic;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        IEnumerable<EmployeeDTO> GetAll();

        Result Add(Employee emp);
    }
}
