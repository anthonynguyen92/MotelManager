using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motel.EntityDb.Entities;

namespace Motel.EntityDb.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.Identification).IsRequired();
        }
    }
}
