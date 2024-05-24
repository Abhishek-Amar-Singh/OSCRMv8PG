
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("hi_maintain_version", Schema = "insurance")]
    public class MaintainVersionHI
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long hi_mst { get; set; }
        public long hi_claims_experience { get; set; }
        public long hi_standard_features { get; set; }
        public long hi_product_card { get; set; }
        public long hi_about_insurer { get; set; }
        public long v { get; set; }
        public long health_cat_id { get; set; }
    }
}
