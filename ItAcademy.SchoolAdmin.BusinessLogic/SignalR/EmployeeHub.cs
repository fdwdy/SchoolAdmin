using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    [HubName("EmolyeeSignalRHub")]
    public class EmployeeHub : Hub
    {
        public void Send(IEnumerable<Employee> emps)
        {
            Clients.All.broadcastMessage(emps);
        }
    }
}
