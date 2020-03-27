using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motel.EntityDb.Entities;

namespace Motel.EntityDb.Configuration
{
    public class InforBillConfiguration : IEntityTypeConfiguration<InforBill>
    {
        public void Configure(EntityTypeBuilder<InforBill> builder)
        {
            builder.HasKey(p => p.IdInforBill);
            builder.HasOne(p => p.MotelRoom).WithMany(m => m.InforBills).HasForeignKey(m => m.IdMotel);
            builder.Property(p => p.DateCreate).IsRequired();

        }
    }
}
