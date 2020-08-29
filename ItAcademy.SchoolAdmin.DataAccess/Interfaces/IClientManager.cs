using System;
using ItAcademy.SchoolAdmin.DataAccess.Models.Identity;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
