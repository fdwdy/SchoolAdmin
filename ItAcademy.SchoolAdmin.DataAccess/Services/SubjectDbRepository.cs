using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class SubjectDbRepository : IRepository<SubjectDb>
    {
        private SchoolContext _db;

        private SubjectDb _sbj;

        public SubjectDbRepository(SchoolContext db)
        {
            _db = db;
        }

        public void Create(SubjectDb sbj)
        {
            _sbj = sbj;
            _sbj.Id = Guid.NewGuid().ToString();
            _db.Subjects.Add(_sbj);
        }

        public void Delete(int id)
        {
            SubjectDb sbj = _db.Subjects.Find(id);
            if (sbj != null)
            {
                _db.Subjects.Remove(sbj);
            }
        }

        public async Task DeleteAsync(string id)
        {
            SubjectDb sbj = await _db.Subjects.FindAsync(id);
            _db.Subjects.Remove(sbj);
        }

        public IEnumerable<SubjectDb> GetAll()
        {
            return _db.Subjects;
        }

        public async Task<IEnumerable<SubjectDb>> GetAllAsync()
        {
            return await _db.Subjects.ToListAsync().ConfigureAwait(false);
        }

        public async Task<SubjectDb> GetByIdAsync(string id)
        {
            var sbj = await _db.Subjects
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            return sbj;
        }

        public void Update(SubjectDb sbj)
        {
            _db.Entry(sbj).State = EntityState.Modified;
        }

        public async Task UpdateAsync(SubjectDb sbj)
        {
            _db.Subjects.Attach(sbj);
            _db.Entry(sbj).State = EntityState.Modified;
        }

        public Result Save()
        {
            _db.SaveChanges();
            return Result.Ok();
        }

        public async Task<IEnumerable<SubjectDb>> SearchAsync(string query)
        {
            return await _db.Subjects.Where(x => x.Name.Contains(query)).ToListAsync();
        }

        public async Task<bool> FindByName(string name)
        {
            return await _db.Subjects.AnyAsync(s => s.Name == name);
        }
    }
}
