using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.OrderId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

        }
    }
}
