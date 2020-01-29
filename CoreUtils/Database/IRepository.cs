namespace System1Group.Lib.CoreUtils.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public interface IRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        EntityEntry<T> Attach(T entity);

        EntityEntry<T> Entry(T entity);

        Task<int> SaveChangesAsync();

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        void DeleteRange(IEnumerable<T> entities);

        void AddRange(IEnumerable<T> entities);

        Task<IDbContextTransaction> BeginTransaction();
    }
}
