using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motel.EntityDb.Entities;

namespace Motel.EntityDb.Configuration
{
    public class AppRolesConfiguration : IEntityTypeConfiguration<AppRoles>
    {
        public void Configure(EntityTypeBuilder<AppRoles> builder)
        {
            builder.Property(p => p.Descriptions).IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
