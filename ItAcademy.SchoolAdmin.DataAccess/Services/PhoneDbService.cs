using System.Linq;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class PhoneDbService : IPhoneDbService
    {
        private readonly SchoolContext _context;

        public PhoneDbService(SchoolContext context)
        {
            _context = context;
        }

        public string GetNumberById(string id)
        {
            if (id == null)
            {
                return id;
            }

            var phone = _context.Phones.FirstOrDefault(e => e.Id == id);
            return phone.Number;
        }
    }
}
