namespace Infrastructure.Data.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty; // Insert, Update, Delete
        public string PrimaryKey { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
