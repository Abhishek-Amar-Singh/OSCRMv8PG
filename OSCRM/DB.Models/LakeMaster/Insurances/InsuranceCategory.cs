using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table(name: "category", Schema = "insurance")]
    public class InsuranceCategory : AuditableEntity
    {
        [Key]
        public long id { get; set; }
        public long? category_id { get; set; }
        public string name { get; set; } = null!;
        public long? parent_category_id { get; set; }
        public string? description { get; set; }
        public int? existence_year { get; set; }
    }
}
