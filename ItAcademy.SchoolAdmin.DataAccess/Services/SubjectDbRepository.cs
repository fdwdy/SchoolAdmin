using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class SubjectDbRepository : BaseDbRepository<SubjectDb>, ISubjectDbService
    {
        private SchoolContext _db;

        public SubjectDbRepository(SchoolContext db)
            : base(db)
        {
            _db = db;
        }

        public SubjectDbRepository(SchoolContext db, DbSet<SubjectDb> set)
            : base(db, set)
        {
            _db = db;
        }

        public override async Task<IEnumerable<SubjectDb>> SearchAsync(string query)
        {
            return await _db.Subjects.Where(x => x.Name.Contains(query)).ToListAsync();
        }

        public override async Task<bool> FindByName(string name)
        {
            return await _db.Subjects.AnyAsync(s => s.Name == name);
        }

        public async Task<IEnumerable<SubjectDbStatistics>> GetAllWithEmployeesSorted()
        {
            return await _db.Subjects
                .Select(s => new SubjectDbStatistics
                {
                    Id = s.Id,
                    Name = s.Name,
                    Employees = s.Employees.Select(e => new EmployeeDbSubjectStatistics
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Middlename = e.Middlename,
                        Email = e.Email,
                        Phones = e.Phones,
                    }).ToList(),
                })
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<SubjectDbStatistics> GetByNameWithEmployeesSorted(string name)
        {
            return await _db.Subjects
                .Where(s => s.Name == name)
                .Select(s => new SubjectDbStatistics
                {
                    Id = s.Id,
                    Name = s.Name,
                    Employees = s.Employees.Select(e => new EmployeeDbSubjectStatistics
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Middlename = e.Middlename,
                        Email = e.Email,
                        Phones = e.Phones,
                    }).ToList(),
                })
                .OrderBy(s => s.Name)
                .FirstOrDefaultAsync();
        }
    }
}
