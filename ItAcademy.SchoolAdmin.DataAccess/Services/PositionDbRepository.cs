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
    public class PositionDbRepository : IRepository<PositionDb>
    {
        private SchoolContext _db;

        private PositionDb _pos;

        public PositionDbRepository(SchoolContext db)
        {
            _db = db;
        }

        public void Create(PositionDb pos)
        {
            _pos = pos;
            _pos.Id = Guid.NewGuid().ToString();
            _db.Positions.Add(_pos);
        }

        public void Delete(int id)
        {
            PositionDb pos = _db.Positions.Find(id);
            if (pos != null)
            {
                _db.Positions.Remove(pos);
            }
        }

        public async Task DeleteAsync(string id)
        {
            PositionDb pos = await _db.Positions.FindAsync(id);
            _db.Positions.Remove(pos);
        }

        public Task<bool> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PositionDb> GetAll()
        {
            return _db.Positions;
        }

        public async Task<IEnumerable<PositionDb>> GetAllAsync()
        {
            return await _db.Positions.ToListAsync().ConfigureAwait(false);
        }

        public async Task<PositionDb> GetByIdAsync(string id)
        {
            return await _db.Positions.FindAsync(id);
        }

        public Result Save()
        {
            _db.SaveChanges();
            return Result.Ok();
        }

        public async Task<IEnumerable<PositionDb>> SearchAsync(string query)
        {
            return await _db.Positions.Where(x => x.Name.Contains(query)).ToListAsync();
        }

        public void Update(PositionDb pos)
        {
            _db.Entry(pos).State = EntityState.Modified;
        }

        public async Task UpdateAsync(PositionDb pos)
        {
            _db.Positions.Attach(pos);
            _db.Entry(pos).State = EntityState.Modified;
        }
    }
}
