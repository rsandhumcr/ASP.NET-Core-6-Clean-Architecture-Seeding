using CompanyNameSpace.ProjectName.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyNameSpace.ProjectName.Domain.Entities
{
    public class EntityOne : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityOneId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        
    }
}
