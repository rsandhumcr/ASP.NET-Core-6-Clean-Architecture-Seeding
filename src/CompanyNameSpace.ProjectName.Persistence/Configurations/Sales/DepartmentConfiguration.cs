using CompanyNameSpace.ProjectName.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyNameSpace.ProjectName.Persistence.Configurations.Sales;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(e => e.DepartmentId)
            .ValueGeneratedOnAdd();
    }
}