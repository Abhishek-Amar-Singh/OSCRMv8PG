
namespace Shared.Lib.Models
{
    public class AuditableEntity
    {
        public bool is_active { get; set; } = true;
        public DateTimeOffset created_at { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset last_updated_at { get; set; } = DateTimeOffset.Now;
    }

    public class Auditable : AuditableEntity
    {
        public Guid created_by { get; set; }
        public Guid last_updated_by { get; set; }
    }
}
