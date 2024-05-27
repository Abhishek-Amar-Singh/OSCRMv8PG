namespace OSCRM.Web.Api.Models.Customers.Exceptions
{
    public class CustomerSqlException : Exception
    {
        public CustomerSqlException(Exception innerException)
            : base(message: "Sql service error occurred, contact support.", innerException) { }
    }
        
}
