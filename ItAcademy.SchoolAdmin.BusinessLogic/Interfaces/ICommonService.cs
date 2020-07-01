using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface ICommonService<TEntity>
        where TEntity : class
    {
        Result Add(TEntity entity);

        IEnumerable<TEntity> GetAll();

        Task<Result<TEntity>> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        Task RemoveByIdAsync(string id);

        Task UpdateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> SearchAsync(string query);
    }
}
