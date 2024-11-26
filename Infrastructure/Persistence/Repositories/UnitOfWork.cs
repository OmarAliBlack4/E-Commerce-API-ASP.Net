using Domain.Contracts;
using Domain.Entities;
using Persistence.Data;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public async Task<int> SaveChangesAsync() 
            => await _storeContext.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntitiy<TKey>
            => (IGenericRepository<TEntity, TKey>)
                _repositories.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepository<TEntity, TKey>(_storeContext));
    }
}
