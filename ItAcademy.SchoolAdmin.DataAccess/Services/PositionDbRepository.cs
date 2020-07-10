using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class PositionDbRepository : BaseDbRepository<PositionDb>
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

        public override async Task<IEnumerable<PositionDb>> SearchAsync(string query)
        {
            var result = await _db.Positions.Where(x => x.Name.Contains(query)).ToListAsync();
            return result;
        }
    }
}
