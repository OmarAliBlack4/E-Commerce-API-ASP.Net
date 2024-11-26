using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntitiy<Tkey>
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task AddAsync(TEntity entity) 
            => await _storeContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) 
            => _storeContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) 
            => _storeContext.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false) 
            => trackChanges 
                ? await _storeContext.Set<TEntity>().ToListAsync() 
                : await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetAsync(Tkey id) 
            => await _storeContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> GetAsync(Specifications<TEntity> specifications)
           => await ApplaySpecifications(specifications).FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications)
            => await ApplaySpecifications(specifications).ToListAsync();    

        private IQueryable<TEntity> ApplaySpecifications(Specifications<TEntity> specifications)
            =>SpecificationEvaluator.GetQuery<TEntity>(_storeContext.Set<TEntity>(), specifications);

        public async Task<int> CountAsync(Specifications<TEntity> specifications)
         =>   await SpecificationEvaluator.GetQuery(_storeContext.Set<TEntity>(), specifications).CountAsync();
    }
}
