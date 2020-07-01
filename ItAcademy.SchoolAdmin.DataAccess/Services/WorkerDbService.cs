using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class WorkerDbService : IWorkerDbService
    {
        private readonly SchoolContext _context;

        public WorkerDbService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<WorkerDb> GetRelatedEntities(string id)
        {
            var result = _context.Positions
                .Where(s => s.Id == id)
                .Select(st => new
                {
                    PositionId = st.Id,
                    PositionName = st.Name,
                    EmployeeIds = st.Employees.Select(emp => emp.Id)
                })
                .AsEnumerable()
                .Select(st => new WorkerDb()
                {
                    PositionId = st.PositionId,
                    PositionName = st.PositionName,
                    EmployeeIds = st.EmployeeIds.ToArray()
                })
                .ToList();
            return result.First();
        }

        public async Task SaveRelatedEntities(string id, string[] relatedIds)
        {
            var position = await _context.Positions
                .Where(s => s.Id == id)
                .Include(s => s.Employees).SingleOrDefaultAsync();
            if (relatedIds == null)
            {
                position.Employees = new List<EmployeeDb>();
            }
            else
            {
                position.Employees.Clear();
                var workers = _context.Employees
                    .Where(e => relatedIds.Contains(e.Id))
                    .ToList();
                position.Employees = workers;
            }

            await _context.SaveChangesAsync();
        }
    }
}
