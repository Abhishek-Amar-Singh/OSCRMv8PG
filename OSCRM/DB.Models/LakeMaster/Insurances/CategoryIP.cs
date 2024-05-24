
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ip_category", Schema = "insurance")]
    public class CategoryIP : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long? category_id { get; set; }
        public string? uin_code { get; set; }
        public string? logo_url { get; set; }
        public string name { get; set; } = null!;
        public long? parent_category_id { get; set; }
        public string? financial_year { get; set; }
        public long? distribution_method_id { get; set; }
        public long? plan_type_id { get; set; }
        public DateOnly? opening_date { get; set; }
        public DateOnly? closing_date { get; set; }
        public string? description { get; set; }
        public int? existing_year { get; set; }
        public long version { get; set; }
    }
}
