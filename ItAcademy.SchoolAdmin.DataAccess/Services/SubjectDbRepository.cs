using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class SubjectDbRepository : BaseDbRepository<SubjectDb>
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
    }
}
