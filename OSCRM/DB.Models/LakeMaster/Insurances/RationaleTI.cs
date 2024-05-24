
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ti_rationale", Schema = "insurance")]
    public class RationaleTI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long category_id { get; set; }
        public decimal policy_duration_score { get; set; }
        public decimal premium_payment_option_score { get; set; }
        public decimal premium_payment_frequency_score { get; set; }
        public decimal maximum_maturity_age_score { get; set; }
        public decimal rider_type_score { get; set; }
        public decimal max_age_cover_ci_score { get; set; }
        public decimal max_age_cover_accidental_disability_score { get; set; }
        public long version { get; set; }
    }
}
