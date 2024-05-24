
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("hi_standard_feature", Schema = "insurance")]
    public class StandardFeatureHI : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long category_id { get; set; }
        public string pre_hospitalisation { get; set; } = null!;
        public string post_hospitalisation { get; set; } = null!;
        public string? daycare_treatments { get; set; }
        public string? ambulance_cover { get; set; }
        public string? domiciliary_hospitalisation { get; set; }
        public string? organ_donor_cover { get; set; }
        public string? second_opinion { get; set; }
        public string? daily_allowance { get; set; }
        public string? ayush_treatment { get; set; }
        public string? modern_treatment { get; set; }
        public long version { get; set; }
    }
}
