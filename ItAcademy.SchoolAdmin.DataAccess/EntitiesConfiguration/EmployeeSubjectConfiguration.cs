﻿using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    public class EmployeeSubjectConfiguration : EntityTypeConfiguration<EmployeeSubject>
    {
        public EmployeeSubjectConfiguration()
        {
            ToTable("EmployeeSubjects");
            HasKey(sc => new { sc.EmployeeId, sc.SubjectId });
        }
    }
}
