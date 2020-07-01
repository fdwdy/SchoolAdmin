using System.Threading.Tasks;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public interface ISchoolHub
    {
        void Initialize(string method);

        Task NotifyAll(object[] args = null);
    }
}
