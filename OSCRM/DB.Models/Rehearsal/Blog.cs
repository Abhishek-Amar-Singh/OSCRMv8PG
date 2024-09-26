
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.Rehearsal
{
    [Table("blog")]
    public class Blog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string title { get; set; } = null!;
        [Column(TypeName = "NVARCHAR(2048)")]
        public string url { get; set; } = null!;
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string? description { get; set; }
        public DateTimeOffset? issued_on { get; set; }
        [Column(TypeName = "NVARCHAR(75)")]
        public string? written_by { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        public string? source { get; set; }
        [Column(TypeName = "NVARCHAR(500)")]
        public string? eng_quote { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string email { get; set; } = null!;
    }
}
