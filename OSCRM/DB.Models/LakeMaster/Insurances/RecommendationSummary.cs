
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ipe_recommendation_summary", Schema = "insurance")]
    public class RecommendationSummary
    {
        [Key]
        public Guid customer_code { get; set; }
        public decimal existing_annual_premium { get; set; }
        public decimal existing_cover { get; set; }
        public decimal recommended_term_annual_premium { get; set; }
        public decimal recommended_term_cover { get; set; }
        public decimal net_savings { get; set; }
    }
}
