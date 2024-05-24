namespace OSCRM.Web.Api.Models.Customers.Exceptions
{
    public class AlreadyExistsCustomerException : Exception
    {
        public AlreadyExistsCustomerException(string email) :
            base(message: $"Customer having email address '{email}' is already exists") { }
    }
}
