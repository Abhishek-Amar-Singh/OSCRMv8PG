
using Shared.Lib.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models.LakeMaster.Customers
{
    [Table("customer_profile")]
    public class CustomerProfile : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public Guid user_code { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public DateOnly? dob { get; set; }
        public string? gender { get; set; }
        public string? mobile_number { get; set; }
        public string? email { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? money_sign { get; set; }
        public string? martial_status { get; set; }
        public string? education { get; set; }
        public long? retirement_age { get; set; }
        public string? member_id { get; set; }
        public string? pan_no { get; set; }
        public string? pan_name { get; set; }
        public bool? email_verified { get; set; }
        public string? ms_completed_date { get; set; }
    }
}
