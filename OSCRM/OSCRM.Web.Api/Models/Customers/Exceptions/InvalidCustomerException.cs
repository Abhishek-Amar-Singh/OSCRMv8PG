namespace OSCRM.Web.Api.Models.Customers.Exceptions
{
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string[] parameterValues, string paramaterName) :
            base(message: $"Invalid customer: Parameter(name = {paramaterName}, value(s) = [{string.Join(',', parameterValues)}])") { }
        
    }
}
