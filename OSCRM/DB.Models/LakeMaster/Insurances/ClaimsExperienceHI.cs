using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("hi_claims_experience", Schema = "insurance")]
    public class ClaimsExperienceHI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string? logo_url { get; set; }
        public long category_id { get; set; }
        public decimal claim_settled_ratio { get; set; }
        public decimal ageing_of_claim { get; set; }
        public decimal incurred_claim_ratio { get; set; }
        public long? network_hospitals { get; set; }
        public decimal claim_settled_ratio_abs_amt { get; set; }
        public long version { get; set; }
    }
}
