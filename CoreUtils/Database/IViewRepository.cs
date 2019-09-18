namespace System1Group.Lib.CoreUtils.Database
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IViewRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}
