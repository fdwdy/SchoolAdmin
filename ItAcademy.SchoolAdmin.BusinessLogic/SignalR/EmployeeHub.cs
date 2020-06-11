using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    class EmployeeHub : Hub
    {
        public void Send(IEnumerable<Employee> emps)
        {
            Clients.All.broadcastMessage(emps);
        }
    }
}
