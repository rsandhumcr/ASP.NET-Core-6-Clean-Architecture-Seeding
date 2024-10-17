using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyNameSpace.ProjectName.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(e => e.OrderId)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}