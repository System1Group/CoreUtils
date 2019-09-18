namespace System1Group.Lib.CoreUtils.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class EfViewRepository<T> : IViewRepository<T>
        where T : class
    {
        private readonly DbContext context;
        private readonly DbQuery<T> dbQuery;
        private bool disposed;

        public EfViewRepository(DbContext context)
        {
            this.context = context;
            this.dbQuery = this.context.Query<T>();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await this.GetAll().AnyAsync(predicate);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this.dbQuery.Where(predicate).AsQueryable();
        }

        public IQueryable<T> GetAll()
        {
            return this.dbQuery.AsQueryable();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.context?.Dispose();
            }

            this.disposed = true;
        }
    }
}
