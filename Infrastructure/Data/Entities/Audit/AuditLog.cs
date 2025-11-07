namespace Infrastructure.Data.Entities.Audit
{
    public class AuditLog
    {
        public int AuditId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty; // Insert, Update, Delete
        public int PrimaryKey { get; set; }
        public string? Value { get; set; } = string.Empty;
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
