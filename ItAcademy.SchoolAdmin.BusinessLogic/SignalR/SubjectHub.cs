using System.Collections.Generic;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using Microsoft.AspNet.SignalR;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class SubjectHub : Hub
    {
       public void Send(IEnumerable<Subject> subjects)
       {
       }
    }
}
