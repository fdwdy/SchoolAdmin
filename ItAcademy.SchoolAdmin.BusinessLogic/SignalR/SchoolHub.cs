using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class SchoolHub : Hub, ISchoolHub
    {
        public SchoolHub()
        {
        }

        public string Method { get; set; }

        public void Initialize(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
            {
                throw new ArgumentException("message", nameof(method));
            }

            Method = method;
        }

        public Task NotifyAll(object[] args = null)
        {
            args = args ?? new object[0];
            object[] newArray = new object[] { args, Method };
            return GlobalHost.ConnectionManager.GetHubContext<SchoolHub>().Clients.All.broadcast(newArray);
        }
    }
}
