
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("insurance_policy_evaluation", Schema = "insurance")]
    public class InsurancePolicyEvaluation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public Guid user_code { get; set; }
        public string policy_name { get; set; } = null!;
        public int plan_type_id { get; set; }
        public string plan_type { get; set; } = null!;
        public int? plan_category_id { get; set; }
        public string? plan_category { get; set; }
        public DateOnly policy_start_date { get; set; }
        public int policy_tenure { get; set; }
        public int premium_paying_tenure { get; set; }
        public decimal annual_premium { get; set; }
        public decimal life_cover { get; set; }
        public decimal premium_paid_till_date { get; set; }
        public decimal premium_payable { get; set; }
        public string? suggested_action { get; set; }
        public string? surrender_value { get; set; }
        public decimal surrender_value_integer { get; set; }
        public int? scenario { get; set; }
        public double? accrued_bonus { get; set; }
        public long user_action_id { get; set; } = 339;
        public decimal? surrender_val_received { get; set; }
        public decimal? premium_saved { get; set; }
        public decimal? commission_saved { get; set; }
        public DateTime? last_updated_at { get; set; }
        public long? payment_frequency_mode_id { get; set; }
    }
}
