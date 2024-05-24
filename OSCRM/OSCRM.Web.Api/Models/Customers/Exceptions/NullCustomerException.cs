namespace OSCRM.Web.Api.Models.Customers.Exceptions
{
    public class NullCustomerException : Exception
    {
        public NullCustomerException() : base(message: "The customer is null.") { }
    }
}
