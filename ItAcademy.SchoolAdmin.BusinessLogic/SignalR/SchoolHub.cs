using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class SchoolHub : Hub, ISchoolHub
    {
        public const string HubName = "schoolModificationHub";

        private readonly IHubContext<SchoolHub> _hubContext;

        private string Method { get; set; }

        public void Initialize(string method)
        {
            Method = method;
        }

        public Task NotifyAll(object[] args = null)
        {
            args = args ?? new object[0];

            return _hubContext.Clients.All.NotifyAll(args);
        }
    }
}
