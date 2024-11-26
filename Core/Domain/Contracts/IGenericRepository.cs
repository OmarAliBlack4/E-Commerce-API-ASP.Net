using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntitiy<TKey>
    {
        Task<TEntity?> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
        Task<TEntity?> GetAsync(Specifications<TEntity> specifications);
        Task<int> CountAsync(Specifications<TEntity> specifications);
        Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
