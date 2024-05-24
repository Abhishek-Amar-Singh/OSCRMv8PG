namespace OSCRM.Web.Api.Models.Customers.Exceptions
{
    public class CustomerValidationException : Exception
    {
        public CustomerValidationException(Exception innerException)
            : base(message: "Invalid input, contact support.", innerException) { }
    }
}
