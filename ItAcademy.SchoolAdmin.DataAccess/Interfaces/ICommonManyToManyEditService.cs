using System.Threading.Tasks;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface ICommonManyToManyEditService<TEntity, TId, TRelatedEntityId>
        where TEntity : class
    {
        Task<TEntity> GetRelatedEntities(TId id);

        Task SaveRelatedEntities(TId id, TRelatedEntityId relatedIds);
    }
}
