
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models.LakeMaster.PMWells
{
    [Table("pmwell_response")]
    public class PMWellResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        [Required]
        public Guid user_code { get; set; }
        [Required]
        public Int64 category_id { get; set; }
        public Int64? duration { get; set; }
        public Int64? start_age { get; set; }
        [Required]
        public double cover { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public bool is_active { get; set; } = true;
    }
}
