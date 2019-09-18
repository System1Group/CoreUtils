namespace System1Group.Lib.CoreUtils.Tests.Database
{
    using Microsoft.EntityFrameworkCore;

    public class FakeDbContext : DbContext
    {
        public FakeDbContext(DbContextOptions<FakeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FakeTable> FakeTable { get; set; }
    }
}
