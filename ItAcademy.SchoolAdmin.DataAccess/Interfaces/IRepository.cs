namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ItAcademy.SchoolAdmin.Infrastructure;

    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        T GetEmployee(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<Result<T>> UpdateAsync(T item);

        Task<Result> DeleteAsync(int id);

        Result Save();
    }
}