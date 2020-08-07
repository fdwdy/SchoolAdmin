using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class MessageDbService : IMessageDbService
    {
        private SchoolContext _db;

        public MessageDbService(SchoolContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MessageDbWithRecipientName>> GetAllSortedByStatusAndTimeAsync()
        {
            return await _db.Messages
                .Join(
                _db.Employees,
                msg => msg.RecipientId,
                emp => emp.Id,
                (message, employee) => new MessageDbWithRecipientName
                {
                    Id = message.Id,
                    RecipientId = employee.Id,
                    RecipientFullName = employee.Name + " " + employee.Middlename + " " + employee.Surname,
                    Status = message.Status,
                    Text = message.Text,
                    Time = message.Time,
                    Type = message.Type
                })
                .OrderByDescending(msg => msg.Status).ThenBy(msg => msg.Time)
                .ToListAsync();
        }

        public async Task<MessageDbWithRecipientName> GetByIdAsync(string id)
        {
            return await _db.Messages
                .Join(
                _db.Employees,
                msg => msg.RecipientId,
                emp => emp.Id,
                (message, employee) => new MessageDbWithRecipientName
                {
                    Id = message.Id,
                    RecipientId = employee.Id,
                    Text = message.Text,
                })
                .FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public Result<MessageDb> Save(MessageDb msg)
        {
            _db.Messages.Add(msg);
            _db.SaveChanges();
            return Result<MessageDb>.Ok(msg);
        }
    }
}
