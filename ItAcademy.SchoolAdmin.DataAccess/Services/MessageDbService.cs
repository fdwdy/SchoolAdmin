using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
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

        public Result<MessageDb> Save(MessageDb msg)
        {
            _db.Messages.Add(msg);
            _db.SaveChanges();
            return Result<MessageDb>.Ok(msg);
        }
    }
}
