
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ti_mst", Schema = "insurance")]
    public class MasterTI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long category_id { get; set; }
        public string uin_code { get; set; } = null!;
        public string? gender { get; set; }
        public decimal min_age { get; set; }
        public decimal? max_age { get; set; }
        public int policy_term { get; set; }
        public decimal sum_assured { get; set; }
        public decimal annual_premium { get; set; }
        public decimal max_age_at_maturity { get; set; }
        public decimal max_policy_term { get; set; }
        public string[] premium_payment_options { get; set; } = null!;
        public string[] payment_frequency { get; set; } = null!;
        public string payout_option { get; set; } = null!;
        public string rider_type { get; set; } = null!;
        public int? nof_diseases_covered_critical_illness { get; set; }
        public int? max_age_cover_for_ci { get; set; }
        public int? max_age_cover_for_accidental_disability { get; set; }
        public int max_age_at_entry { get; set; }
        public string min_sum_assured { get; set; } = null!;
        public string max_sum_assured { get; set; } = null!;
        public decimal solvency_ratio { get; set; }
        public decimal pr_13M_by_nof_policies_per { get; set; }
        public decimal pr_13M_by_annualized_premium_per { get; set; }
        public decimal pr_61M_by_nof_policies_per { get; set; }
        public decimal pr_61M_by_by_annualized_premium_per { get; set; }
        public decimal commission_ratio_per { get; set; }
        public decimal claimed_paid_benefit_amt_per { get; set; }
        public decimal claim_settlement_ratio_per { get; set; }
        public decimal claim_paid_nof_policies_per { get; set; }
        public decimal nof_claims_complaints_per_10000 { get; set; }
        public decimal aoc_paid_less_than_3_mos_per { get; set; }
        public decimal aoc_paid_from_3_to_6_mos_per { get; set; }
        public decimal aoc_paid_from_6_to_12_mos_per { get; set; }
        public decimal aoc_paid_more_than_1_yr_per { get; set; }
        public decimal aoc_pending_eoy_per { get; set; }
        public long version { get; set; }
    }
}
