
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ti_unique_sentence", Schema = "insurance")]
    public class UniqueSentenceTI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long category_id { get; set; }
        public string logo_url { get; set; } = null!;
        public string max_maturity_age { get; set; } = null!;
        public string premium_payment_mode { get; set; } = null!;
        public string premium_payment_frequency { get; set; } = null!;
        public string death_benefit_payout_option { get; set; } = null!;
        public string solvency_ratio { get; set; } = null!;
        public string pr_13M_by_nof_policies { get; set; } = null!;
        public string pr_61M_by_nof_policies { get; set; } = null!;
        public string commission_ratio { get; set; } = null!;
        public string csr_value_of_claims { get; set; } = null!;
        public string csr_nof_policies { get; set; } = null!;
        public string nof_claims_complaints_per_10000 { get; set; } = null!;
        public string aoc_avg_num_and_amt { get; set; } = null!;
        public long version { get; set; }

    }
}
