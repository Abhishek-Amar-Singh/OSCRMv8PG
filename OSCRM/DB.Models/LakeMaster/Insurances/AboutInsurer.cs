using Shared.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("about_insurer", Schema = "insurance")]
    public class AboutInsurer : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long category_id { get; set; }
        public string description { get; set; } = null!;
        public int founded_in { get; set; }
        public string ceo { get; set; } = null!;
        public string headquarters { get; set; } = null!;
        public string aum { get; set; } = null!;
        public string? gwp { get; set; }
        public string? combined_ratio { get; set; }
        public string? premium_underwritten { get; set; }
        public double? nof_policies { get; set; }
        public double? nof_claims { get; set; }
        public long version { get; set; }

    }
}
