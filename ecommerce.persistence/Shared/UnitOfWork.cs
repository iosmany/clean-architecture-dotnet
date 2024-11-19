using Azure.Core;
using ecommerce.application;
using ecommerce.application.Persistence;
using LanguageExt;
using System.Collections.Concurrent;

namespace ecommerce.persistence.Shared
{
    class UnitOfWork : IUnitOfWork
    {
        readonly IDatabaseService _databaseService;
        readonly ConcurrentDictionary<Type, object> repos = new ConcurrentDictionary<Type, object>();

        public UnitOfWork(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task SaveChangesAsync()
        {
            await _databaseService.SaveChangesAsync();
        }

        public IRepository<E> GetRepository<E>() where E: class
        {
            IRepository<E>? repository = (IRepository<E>?)repos.GetValueOrDefault(typeof(IRepository<E>));
            if (repository != null)
                return repository;

            repository = new Repository<E>(_databaseService, _databaseService.Set<E>());
            repos.TryAdd(typeof(IRepository<E>), repository);
            return repository;
        }

        public void Dispose() => _databaseService?.Dispose();
        public ValueTask DisposeAsync()
        {
            Dispose();
            return ValueTask.CompletedTask;
        }
    }
}
