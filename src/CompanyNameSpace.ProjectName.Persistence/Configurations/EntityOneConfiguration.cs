using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyNameSpace.ProjectName.Persistence.Configurations;

public class EntityOneConfiguration : IEntityTypeConfiguration<EntityOne>
{
    public void Configure(EntityTypeBuilder<EntityOne> builder)
    {
        builder.Property(e => e.EntityOneId)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Price)
            .HasPrecision(38, 18);
    }
}