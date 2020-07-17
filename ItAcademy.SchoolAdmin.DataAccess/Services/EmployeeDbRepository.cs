using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class EmployeeDbRepository : BaseDbRepository<EmployeeDb>, IEmployeeDbService
    {
        private SchoolContext _db;

        public EmployeeDbRepository(SchoolContext db)
            : base(db)
        {
            _db = db;
        }

        public EmployeeDbRepository(SchoolContext db, DbSet<EmployeeDb> set)
            : base(db, set)
        {
            _db = db;
        }

        public override void Create(EmployeeDb item)
        {
            foreach (var phone in item.Phones)
            {
                phone.Id = Guid.NewGuid().ToString();
                _db.Entry(phone).State = EntityState.Added;
            }

            base.Create(item);
        }

        public override async Task UpdateAsync(EmployeeDb item)
        {
            await _db.Phones.Where(p => p.EmployeeId == item.Id)
                .ForEachAsync(d => _db.Entry(d).State = EntityState.Deleted);
            foreach (var phone in item.Phones)
            {
                if (phone.Id == null)
                {
                    phone.Id = Guid.NewGuid().ToString();
                }

                _db.Entry(phone).State = EntityState.Added;
            }

            _db.Employees.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public override async Task<EmployeeDb> GetByIdAsync(string id)
        {
            return await _db.Employees.Include(e => e.Phones)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<EmployeeDb>> GetAllAsync()
        {
            return await _db.Employees.Include(e => e.Phones).ToListAsync();
        }

        public override async Task<IEnumerable<EmployeeDb>> SearchAsync(string query)
        {
            var result = await _db.Employees.Where(x =>
               x.Name.Contains(query) || x.Middlename.Contains(query) ||
               x.Surname.Contains(query) || x.Email.Contains(query) ||
               x.Phones.Any(p => p.Number.Contains(query)) || x.Phone.Contains(query))
               .Include(e => e.Phones).ToListAsync();
            return result;
        }

        public override Task<bool> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<EmployeeDb>> GetAllWithPhonesSubjectsAndPositionsSorted()
        {
            return await _db.Employees
                         .Include(e => e.Phones).Include(e => e.Subjects).Include(e => e.Positions)
                         .OrderBy(e => e.Surname).ThenBy(e => e.Name).ThenBy(e => e.Middlename)
                         .ThenBy(e => e.Email).ThenByDescending(e => e.BirthDate).ToListAsync();
        }
    }
}
