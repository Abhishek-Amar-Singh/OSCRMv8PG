using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json;

namespace OSCRM.Web.Api.Models.Customers.Exceptions
{
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string[] parameterValues, string parameterName) :
            base(message: CustomizeMessage(parameterValues, parameterName)) { }
        
        private static string CustomizeMessage(string[] parameterValues, string parameterName)
        {
            var parameters = new
            {
                parameterMsg = "Customer is invalid",
                parameterName = parameterName,
                parameterValues = parameterValues
            };

            return JsonSerializer.Serialize(parameters);
        }
    }
}
