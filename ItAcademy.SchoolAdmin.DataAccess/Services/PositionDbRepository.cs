using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class PositionDbRepository : BaseDbRepository<PositionDb>, IPositionDbService
    {
        private SchoolContext _db;

        public PositionDbRepository(SchoolContext db)
            : base(db)
        {
            _db = db;
        }

        public PositionDbRepository(SchoolContext db, DbSet<PositionDb> set)
            : base(db, set)
        {
            _db = db;
        }

        public override async Task<bool> FindByName(string name)
        {
            return await _db.Positions.AnyAsync(s => s.Name == name);
        }

        public async Task<IEnumerable<PositionDbStatistics>> GetAllWithEmployeesSorted()
        {
            return await _db.Positions
                .Select(s => new PositionDbStatistics
                {
                    Id = s.Id,
                    Name = s.Name,
                    MaxEmployees = s.MaxEmployees,
                    Employees = s.Employees.Select(e => new EmployeeDbPositionStatistics
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Middlename = e.Middlename,
                        Email = e.Email,
                        Phones = e.Phones,
                        BirthDate = e.BirthDate,
                        Subjects = e.Subjects
                    }).ToList(),
                })
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<PositionDbStatistics> GetByNameWithEmployeesSorted(string name)
        {
            return await _db.Positions
                .Select(s => new PositionDbStatistics
                {
                    Id = s.Id,
                    Name = s.Name,
                    MaxEmployees = s.MaxEmployees,
                    Employees = s.Employees.Select(e => new EmployeeDbPositionStatistics
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Middlename = e.Middlename,
                        Email = e.Email,
                        Phones = e.Phones,
                        BirthDate = e.BirthDate,
                        Subjects = e.Subjects
                    }).ToList(),
                })
                .OrderBy(s => s.Name)
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<PositionDb>> SearchAsync(string query)
        {
            var result = await _db.Positions.Where(x => x.Name.Contains(query)).ToListAsync();
            return result;
        }
    }
}
