
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("ti_maintain_version", Schema = "insurance")]
    public class MaintainVersionTI
    {
        public long id { get; set; }
        public long ti_mst { get; set; }
        public long ti_about_insurer { get; set; }
        public long ti_product_feature { get; set; }
        public long ti_unique_sentence { get; set; }
        public long ti_rationale { get; set; }
        public long v { get; set; }
        public long term_cat_id { get; set; }

    }
}
