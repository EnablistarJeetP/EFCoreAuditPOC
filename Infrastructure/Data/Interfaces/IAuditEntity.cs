namespace Infrastructure.Data.Interfaces
{
    public interface IAuditEntity
    {
        public int AuditId { get; set; }

        public DateTime AuditDate { get; set; }

        public string? UserName { get; set; }

        public string? Action { get; set; }
    }
}
