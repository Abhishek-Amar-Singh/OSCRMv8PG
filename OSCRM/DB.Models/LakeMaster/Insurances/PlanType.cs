using Shared.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Insurances
{
    [Table("plan_type", Schema = "insurance")]
    public class PlanType : AuditableEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public int? parent_type_id { get; set; }
        public string? description { get; set; }
        public long? category_id { get; set; }
    }
}
