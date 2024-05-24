
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("scenario_based_recommendation", Schema = "insurance")]
    public class ScenarioBasedRecommendation : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long plan_type_id { get; set; }
        public string? plan_category_description { get; set; }
        public long scenario { get; set; }
        public string action_rule { get; set;  } = null!;
        public string? applicability { get; set; }
        public string? rationale { get; set; }
        public string? based_on_suggested { get; set; }
        public string? remark { get; set; }
        public string comment { get; set; } = null!;
    }
}
