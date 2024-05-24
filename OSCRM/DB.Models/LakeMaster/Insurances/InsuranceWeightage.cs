using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table(name: "weightage", Schema = "insurance")]
    public class InsuranceWeightage : AuditableEntity
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; } = null!;
        public decimal? weightage { get; set; } = null;
        public long? parent_parameter_id { get; set; } = null;
        public long category_id { get; set; }
    }
}
