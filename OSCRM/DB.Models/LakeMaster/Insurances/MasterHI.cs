
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("hi_mst", Schema = "insurance")]
    public class MasterHI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long category_id { get; set; }
        public string? uin_code { get; set; }
        public decimal cover_plan { get; set; }
        public decimal? pricing_1a { get; set; }
        public decimal? min_age { get; set; }
        public decimal? max_age { get; set; }
        public decimal? pricing_1a_1c { get; set; }
        public decimal? pricing_1a_2c { get; set; }
        public decimal? pricing_2a { get; set; }
        public decimal? pricing_2a_1c { get; set; }
        public decimal? pricing_2a_2c { get; set; }
        public decimal? min_age_ff { get; set; }
        public decimal? max_age_ff { get; set; }
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
        public long version { get; set; }
        public DateOnly? as_on_date { get; set; }
    }
}
