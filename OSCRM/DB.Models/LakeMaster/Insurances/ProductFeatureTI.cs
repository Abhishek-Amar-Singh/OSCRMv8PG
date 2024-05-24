
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ti_product_feature", Schema = "insurance")]
    public class ProductFeatureTI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public decimal min_score { get; set; }
        public decimal max_score { get; set; }
        public string pricing { get; set; } = null!;
        public string? policy_duration { get; set; }
        public string? claim_payout { get; set; }
        public string[]? premium_payout_mode { get; set; }
        public string[]? premium_payout_frequency { get; set; }
        public string? max_maturity_age { get; set; }
        public string? solvency_ratio { get; set; }
        public string? rider_type { get; set; }
        public string claim_settled { get; set; } = null!;
        public string nof_claims_registered_per_10000 { get; set; } = null!;
        public string ageing_of_claim { get; set; } = null!;
        public string pr_13M_by_annualized_premium { get; set; } = null!;
        public string pr_13M_by_no_of_policies { get; set; } = null!;
        public long version { get; set; }

    }
}
