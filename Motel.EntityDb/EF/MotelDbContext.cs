using Microsoft.EntityFrameworkCore;
using Motel.EntityDb.Configuration;
using Motel.EntityDb.Entities;

namespace Motel.EntityDb.EF
{
    public class MotelDbContext : DbContext
    {
        public MotelDbContext(DbContextOptions model) : base(model)
        {
        }

        public DbSet<MotelRoom> MotelRooms { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InforBill> InforBills { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotelRoomConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InforBillConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
