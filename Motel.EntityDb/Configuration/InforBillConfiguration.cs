using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motel.EntityDb.Entities;

namespace Motel.EntityDb.Configuration
{
    public class InforBillConfiguration : IEntityTypeConfiguration<InforBill>
    {
        public void Configure(EntityTypeBuilder<InforBill> builder)
        {
            builder.HasKey(i => i.Id);
        }
    }
}
