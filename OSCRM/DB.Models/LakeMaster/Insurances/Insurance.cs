using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Lib.Models;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("insurance")]
    public class Insurance : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public Guid user_code { get; set; }
        public long category_id { get; set; }
        public double? accrued_bonus { get; set; }
        public DateTime? expiry { get; set; }
        public bool is_manual_entry { get; set; } = false;
        public string? fetched_source { get; set; } = string.Empty;
        public long months { get; set; } = 1;
        public double? coverage { get; set; }
        public double? annual_premium { get; set; }
        public double? pending_tenure { get; set; }
        public long? payment_frequency { get; set; }
        public DateOnly? start_date { get; set; }
        public DateOnly? maturity_date { get; set; }
        public DateOnly? last_date { get; set; }
        public string? name { get; set; } = string.Empty;
    }
}
