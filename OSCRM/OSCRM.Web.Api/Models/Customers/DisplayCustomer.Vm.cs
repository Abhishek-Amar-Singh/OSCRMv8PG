using DB.Models.OSCRM;

namespace OSCRM.Web.Api.Models.Customers
{
    public class DisplayCustomer
    {
        public Guid id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string? middle_name { get; set; }
        public string last_name { get; set; } = string.Empty;
        public string email_address { get; set; } = string.Empty;
        public string mobile_number { get; set; } = string.Empty;
        public long city_id { get; set; } = 0L;
        public string city { get; set; } = string.Empty;
        public long profession_id { get; set; } = 0L;
        public string profession { get; set; } = string.Empty;
        public string pan_number { get; set; } = string.Empty;
    }
}
