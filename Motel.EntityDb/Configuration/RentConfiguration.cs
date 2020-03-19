using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motel.EntityDb.Entities;

namespace Motel.EntityDb.Configuration
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasOne(r => r.MotelRoom).WithOne(m => m.Rent);
            builder.HasOne(r => r.Customer).WithOne(c => c.Rent);
            builder.HasKey(r => r.IdRent);
        }
    }
}
