namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;
    using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
    using ItAcademy.SchoolAdmin.DataAccess.Models;
    using ItAcademy.SchoolAdmin.Infrastructure;

    public class EmployeeDbRepository : IRepository<EmployeeDb>
    {
        private SchoolContext _db;

        private EmployeeDb _emp;

        public EmployeeDbRepository(SchoolContext db)
        {
            _db = db;
        }

        public void Create(EmployeeDb emp)
        {
            _emp = emp;
            _emp.Id = Guid.NewGuid().ToString();
            _db.Employees.Add(_emp);
        }

        public IEnumerable<EmployeeDb> GetAll()
        {
            return _db.Employees;
        }

        public void Update(EmployeeDb emp)
        {
            _db.Entry(emp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            EmployeeDb emp = _db.Employees.Find(id);
            if (emp != null)
            {
                _db.Employees.Remove(emp);
            }
        }

        public async Task DeleteAsync(string id)
        {
            EmployeeDb emp = await _db.Employees.FindAsync(id);
            _db.Employees.Remove(emp);
        }

        public async Task<IEnumerable<EmployeeDb>> GetAllAsync()
        {
            return await _db.Employees.ToListAsync().ConfigureAwait(false);
        }

        public async Task<EmployeeDb> GetByIdAsync(string id)
        {
            return await _db.Employees.FindAsync(id);
        }

        public async Task UpdateAsync(EmployeeDb emp)
        {
            _db.Employees.Attach(emp);
            _db.Entry(emp).State = EntityState.Modified;
        }

        public Result Save()
        {
            try
            {
                _db.SaveChanges();
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail($"Cannot save employee. {"DbUpdateConcurrencyException"}");
            }
            catch (DbUpdateException e)
            {
                return Result.Fail($"Cannot save employee. {"DbUpdateException"}");
            }
            catch (DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(" The validation errors are: ", fullErrorMessage);
                return Result.Fail($"Cannot save employee.  {exceptionMessage}");
            }
            catch (Exception e)
            {
                return Result.Fail($"Cannot save employee. {e.Message}");
            }
        }
    }
}
