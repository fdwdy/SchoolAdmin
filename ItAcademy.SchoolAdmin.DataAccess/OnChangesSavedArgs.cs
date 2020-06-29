using System.Collections.Generic;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess
{
    public class OnChangesSavedArgs
    {
        public OnChangesSavedArgs(IEnumerable<EmployeeDb> emps)
        {
            Employees = emps;
        }

        public IEnumerable<EmployeeDb> Employees { get; set; }
    }
}
