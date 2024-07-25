using ebuy.Application.Common.Interfaces.Repositories;
using ebuy.Domain.Entities;
using ebuy.Domain.Interfaces;
using ebuy.Infraestructure.Context;

namespace ebuy.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EbuyDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(EbuyDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public Application.Common.Interfaces.Repositories.IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (Application.Common.Interfaces.Repositories.IBaseRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new BaseRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
