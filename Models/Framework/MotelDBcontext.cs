using System.Data.Entity;

namespace Models.Framework
{
    public class MotelDBcontext : DbContext
    {
        public MotelDBcontext() : base("name=Motel") { }

        public virtual DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().Property(e => e.UserName).IsUnicode(false);
            modelBuilder.Entity<Account>().Property(e => e.Password).IsUnicode(false);
        }
    }
}
