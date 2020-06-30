﻿using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class TeacherDbService : ITeacherDbService
    {
        private readonly SchoolContext _context;

        public TeacherDbService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<SubjectTeachersDb> GetSubjectTeachers(string subjectId)
        {
            var result = _context.Subjects
                .Where(s => s.Id == subjectId)
                .Select(st => new
                {
                    SubjectId = st.Id,
                    SubjectName = st.Name,
                    EmployeeIds = st.Employees.Select(emp => emp.Id)
                })
                .AsEnumerable()
                .Select(st => new SubjectTeachersDb()
                {
                    SubjectId = st.SubjectId,
                    SubjectName = st.SubjectName,
                    EmployeeIds = st.EmployeeIds.ToArray()
                })
                .ToList();
            return result.First();
        }

        public async Task SaveSubjectTeachers(SubjectTeachersDb subjectTeachers)
        {
            throw new System.NotImplementedException();
        }
    }
}
