using Infrastructure.Data.Interfaces;

namespace Infrastructure.Data.Entities.Audit
{
    public class AuditProductEntity : IAuditEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public int AuditId { get; set; }

        public DateTime AuditDate { get; set; }

        public string? UserName { get; set; }

        public string? Action { get; set; }
    }
}
