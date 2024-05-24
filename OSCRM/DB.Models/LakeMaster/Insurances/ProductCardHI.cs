

using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("hi_product_card", Schema = "insurance")]
    public class ProductCardHI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public decimal min_score { get; set; }
        public decimal max_score { get; set; }
        public string pricing { get; set; } = null!;
        public string claim_settled_ratio { get; set; } = null!;
        public string claim_settled_ratio_abs_amt { get; set; } = null!;
        public string incurred_claim_ratio { get; set; } = null!;
        public string ageing_of_claim { get; set; } = null!;
        public string network_hospitals { get; set; } = null!;
        public long version { get; set; }
    }
}
