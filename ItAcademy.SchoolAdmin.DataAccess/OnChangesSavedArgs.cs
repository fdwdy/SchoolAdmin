using ItAcademy.SchoolAdmin.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.SchoolAdmin.DataAccess
{
    public class OnChangesSavedArgs
    {
        public OnChangesSavedArgs(IEnumerable<EmployeeDb> emps) { Employees = emps; }

        public IEnumerable<EmployeeDb> Employees { get; }
    }
}
