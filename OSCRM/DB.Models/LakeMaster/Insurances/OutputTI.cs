
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ti_output", Schema = "insurance")]
    public class OutputTI
    {
        [Key]
        public string id { get; set; } = null!;
        public string gender { get; set; } = null!;
        public decimal sum_assured { get; set; }
        public decimal min_age { get; set; }
        public decimal? max_age { get; set; }
        public decimal annual_premium { get; set; }
        public string? logo_url { get; set; }
        public long? parent_category_id { get; set; }
        public string? insurer { get; set; }
        public long category_id { get; set; }
        public string uin_code { get; set; } = null!;
        public string insurance_plan { get; set; } = null!;
        public decimal one_fin_score { get; set; }
        public long one_fin_rank { get; set; }
        public long total_ranking { get; set; }
        public string rank_ratio { get; set; } = null!;
        public decimal pricing_score { get; set; }
        public decimal financial_ratios_score { get; set; }
        public decimal product_features_score { get; set; }
        public decimal claims_experience_score { get; set; }
        public decimal brand_existence_score { get; set; }
        public decimal solvency_ratio_score { get; set; }
        public decimal pr_13M_by_nof_policies_score { get; set; }
        public decimal pr_13M_by_annualized_premium_score { get; set; }
        public decimal pr_61M_by_nof_policies_score { get; set; }
        public decimal pr_61M_by_annualized_premium_score { get; set; }
        public decimal commission_ratio_score { get; set; }
        public decimal policy_duration_score { get; set; }
        public decimal death_benefit_payout_option_score { get; set; }
        public decimal premium_payment_mode_score { get; set; }
        public decimal premium_payment_frequency_score { get; set; }
        public decimal max_maturity_age_score { get; set; }
        public decimal rider_type_score { get; set; }
        public decimal nof_diseases_covered_critical_illness_score { get; set; }
        public decimal max_age_cover_ci_score { get; set; }
        public decimal max_age_cover_for_accidental_disability_score { get; set; }
        public decimal csr_value_of_claims_score { get; set; }
        public decimal csr_nof_policies_score { get; set; }
        public decimal nof_claims_complaints_per_10000_score { get; set; }
        public decimal aoc_avg_num_and_amt_score { get; set; }
        public string pricing { get; set; } = null!;
        [Column(TypeName = "json")]
        public string? product_features { get; set; }
        [Column(TypeName = "jsonb")]
        public string? pros { get; set; }
        [Column(TypeName = "jsonb")]
        public string? cons { get; set; }
        [Column(TypeName = "json")]
        public string? ti_about_insurer { get; set; }
        public int sequence { get; set; }
        public long version { get; set; }
        public DateTimeOffset created_at { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset last_updated_at { get; set; } = DateTimeOffset.Now;

    }
}
