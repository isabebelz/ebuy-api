using ebuy.Domain.Entities;
using System.Linq.Expressions;

namespace ebuy.Application.Common.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T evento);
        T AddWithoutCommit(T entity);
        T UpdateWithoutCommit(T entity);
        T Update(T evento);
        IEnumerable<T> UpdateRange(IEnumerable<T> evento);
        void Delete(T evento);
        void DeleteRange(T[] evento);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] including);
    }
}
