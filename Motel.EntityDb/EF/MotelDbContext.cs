using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Motel.EntityDb.Configuration;
using Motel.EntityDb.Entities;
using Motel.EntityDb.Extensions;
using System;

namespace Motel.EntityDb.EF
{
    public class MotelDbContext : IdentityDbContext<AppUser,AppRoles,Guid>
    {
        public MotelDbContext(DbContextOptions model) : base(model)
        {
        }

        public DbSet<MotelRoom> MotelRooms { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InforBill> InforBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotelRoomConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InforBillConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRolesConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim").HasKey(p => p.Id);
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(p => p.UserId);
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim").HasKey(x => x.Id);

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
