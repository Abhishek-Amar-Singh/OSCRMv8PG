
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Lib.Models
{
    [Table(name: "category")]
    public class Category
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; } = null!;
        public long? parent_category_id { get; set; }
        public bool is_active { get; set; } = true;
        public string? guidance { get; set; }
        public double? weightage { get; set; }
        public string? prescripton { get; set; }
    }
}
