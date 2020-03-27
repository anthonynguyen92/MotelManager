using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motel.EntityDb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.EntityDb.Configuration
{
    public class FamilyConfiguration : IEntityTypeConfiguration<FamilyGroup>
    {
        public void Configure(EntityTypeBuilder<FamilyGroup> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Customers).WithMany(p => p.FamilyGroups).HasForeignKey(p => p.User);
        }
    }
}
