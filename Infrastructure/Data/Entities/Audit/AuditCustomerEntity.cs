using Domain.Entities;
using Infrastructure.Data.Interfaces;

namespace Infrastructure.Data.Entities.Audit
{
    public class AuditCustomerEntity : CustomerEntity, IAuditEntity
    {
        public int AuditId { get; set; }

        public DateTime AuditDate { get; set; }

        public string? UserName { get; set; }

        public string? Action { get; set; }
    }
}
