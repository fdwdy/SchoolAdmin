namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    using System;
    using ItAcademy.SchoolAdmin.DataAccess.Models;

    public interface IUnitOfWork : IDisposable
    {
        SchoolContext Db { get; }

        IRepository<EmployeeDb> Employees { get; }

        IRepository<SubjectDb> Subjects { get; }

        IRepository<PositionDb> Positions { get; }

        void Save();
    }
}
