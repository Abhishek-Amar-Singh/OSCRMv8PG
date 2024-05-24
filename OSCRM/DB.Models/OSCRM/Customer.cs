
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.OSCRM
{
    [Table(name: "customer")]
    public class Customer : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string first_name { get; set; } = null!;
        public string? middle_name { get; set; }
        public string last_name { get; set; } = null!;
        public string email_address { get; set; } = null!;
        public string mobile_number { get; set; } = null!;
        public long city_id { get; set; }
        public long profession_id { get; set; }
        public string pan_number { get; set; } = null!;

        #region Foreign Keys of CustomerTbl
        [ForeignKey(nameof(city_id))]
        public Category? city { get; set; }
        [ForeignKey(nameof(profession_id))]
        public Category? profession { get; set; }
        #endregion

    }
}
