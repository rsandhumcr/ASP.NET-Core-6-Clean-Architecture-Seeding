using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyNameSpace.ProjectName.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.CategoryId)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}