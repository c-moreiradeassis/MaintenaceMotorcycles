using System.Linq.Expressions;

namespace Domain.Repository
{
    public interface DatabaseContext<T> where T : class
    {
        void Add(T entity);
        IQueryable<T> GetById(Expression<Func<T, bool>>? filter = null);
        void Remove(T entity);
        Task SaveChangesAsync();
        void Update(T entity);
    }
}
