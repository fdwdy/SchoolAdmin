using System;
using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs
{
    public class EmployeePositionStatistics : EmployeeItemBase
    {
        public DateTime BirthDate { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
