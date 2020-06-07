namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using ItAcademy.SchoolAdmin.Infrastructure;

    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        T GetEmployee(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        Result Save();
    }
}