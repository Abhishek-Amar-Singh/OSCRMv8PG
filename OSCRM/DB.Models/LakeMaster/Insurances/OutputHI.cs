using Shared.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("hi_output", Schema = "insurance")]
    public class OutputHI
    {
        [Key]
        public string id { get; set; } = null!;
        public string uin_code { get; set; } = null!;
        public string logo_url { get; set; } = null!;
        public long? parent_category_id { get; set; }
        public string? insurer { get; set; }
        public long category_id { get; set; }
        public string insurance_plan { get; set; } = null!;
        public decimal cover_plan { get; set; }
        public decimal pricing { get; set; }
        public decimal min_age { get; set; }
        public decimal? max_age { get; set; }
        public string room_description { get; set; } = null!;
        public decimal room_rent_score { get; set; }
        public string no_claim_bonus { get; set; } = null!;
        public decimal ncb_score { get; set; }
        public string recharge_sum_insured { get; set; } = null!;
        public decimal si_recharge_score { get; set; }
        public string pre_existing_disease { get; set; } = null!;
        public decimal ped_score { get; set; }
        public string co_pay { get; set; } = null!;
        public decimal co_pay_score { get; set; }
        public string health_and_wellness { get; set; } = null!;
        public decimal hw_score { get; set; }
        public decimal pricing_score { get; set; }
        public decimal claim_settlement_ratio { get; set; }
        public decimal? csr_score { get; set; }
        public decimal ageing_of_claim { get; set; }
        public decimal? aoc_score { get; set; }
        public decimal incurred_claim_ratio { get; set; }
        public decimal? icr_score { get; set; }
        public long? network_hospitals { get; set; }
        public decimal nh_score { get; set; }
        public decimal claim_settled_ratio_abs_amt { get; set; }
        public decimal csr_abs_amt_score { get; set; }
        public decimal? one_fin_score { get; set; }
        public long one_fin_rank { get; set; }
        public long total_ranking { get; set; }
        public string rank_ratio { get; set; } = null!;
        public decimal? avg_claims_experience_score { get; set; }
        public decimal? avg_product_features_score { get; set; }
        [Column(TypeName = "json")]
        public string standard_feature { get; set; } = null!;
        public string product_card { get; set; } = null!;
        [Column(TypeName = "jsonb")]
        public string? pros { get; set; }
        [Column(TypeName = "jsonb")]
        public string? cons { get; set; }
        [Column(TypeName = "json")]
        public string? hi_about_insurer { get; set; }
        public int sequence { get; set; }
        public long version { get; set; }
        public DateTimeOffset created_at { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset last_updated_at { get; set; } = DateTimeOffset.Now;

    }

    [Table("hi_output_ff", Schema = "insurance")]
    public class OutputFFHI
    {
        [Key]
        public string id { get; set; } = null!;
        public string uin_code { get; set; } = null!;
        public string logo_url { get; set; } = null!;
        public long? parent_category_id { get; set; }
        public string? insurer { get; set; }
        public long category_id { get; set; }
        public string insurance_plan { get; set; } = null!;
        public decimal cover_plan { get; set; }
        public decimal pricing { get; set; }
        public decimal min_age { get; set; }
        public decimal? max_age { get; set; }
        public string room_description { get; set; } = null!;
        public decimal room_rent_score { get; set; }
        public string no_claim_bonus { get; set; } = null!;
        public decimal ncb_score { get; set; }
        public string recharge_sum_insured { get; set; } = null!;
        public decimal si_recharge_score { get; set; }
        public string pre_existing_disease { get; set; } = null!;
        public decimal ped_score { get; set; }
        public string co_pay { get; set; } = null!;
        public decimal co_pay_score { get; set; }
        public string health_and_wellness { get; set; } = null!;
        public decimal hw_score { get; set; }
        public decimal pricing_score { get; set; }
        public decimal claim_settlement_ratio { get; set; }
        public decimal? csr_score { get; set; }
        public decimal ageing_of_claim { get; set; }
        public decimal? aoc_score { get; set; }
        public decimal incurred_claim_ratio { get; set; }
        public decimal? icr_score { get; set; }
        public long? network_hospitals { get; set; }
        public decimal nh_score { get; set; }
        public decimal claim_settled_ratio_abs_amt { get; set; }
        public decimal csr_abs_amt_score { get; set; }
        public decimal? one_fin_score { get; set; }
        public long one_fin_rank { get; set; }
        public long total_ranking { get; set; }
        public string rank_ratio { get; set; } = null!;
        public decimal? avg_claims_experience_score { get; set; }
        public decimal? avg_product_features_score { get; set; }
        [Column(TypeName = "json")]
        public string standard_feature { get; set; } = null!;
        public string product_card { get; set; } = null!;
        [Column(TypeName = "jsonb")]
        public string? pros { get; set; }
        [Column(TypeName = "jsonb")]
        public string? cons { get; set; }
        [Column(TypeName = "json")]
        public string? hi_about_insurer { get; set; }
        public int sequence { get; set; }
        public long version { get; set; }
        public DateTimeOffset created_at { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset last_updated_at { get; set; } = DateTimeOffset.Now;

    }
}
