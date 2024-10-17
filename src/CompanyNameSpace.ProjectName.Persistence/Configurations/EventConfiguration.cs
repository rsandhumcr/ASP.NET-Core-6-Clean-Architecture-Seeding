using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyNameSpace.ProjectName.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(e => e.EventId)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}