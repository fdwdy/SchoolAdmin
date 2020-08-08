using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneDbService _phDbService;

        public PhoneService(IPhoneDbService phoneDbService)
        {
            _phDbService = phoneDbService;
        }

        public string GetNumberById(string id)
        {
            return _phDbService.GetNumberById(id);
        }
    }
}
