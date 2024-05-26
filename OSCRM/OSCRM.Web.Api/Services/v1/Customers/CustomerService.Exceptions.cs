using OSCRM.Web.Api.Models.Categories.Exceptions;
using OSCRM.Web.Api.Models.Customers.Exceptions;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public partial class CustomerService
    {
        private delegate ValueTask<T> ReturningFunction<T>();

        private async ValueTask<T> TryCatch<T>(ReturningFunction<T> returningFunction)
        {
            try
            {
                return await returningFunction();
            }
            catch (NullCustomerException nullCustomerException)
            {
                throw CreateAndLogValidationException(nullCustomerException);
            }
            catch (NullCategoryException nullCategoryException)
            {
                throw CreateAndLogValidationException(nullCategoryException);
            }
            catch (FailedToVerifyCategoryException failedToVerifyCategoryException)
            {
                throw CreateAndLogValidationException(failedToVerifyCategoryException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private CustomerValidationException CreateAndLogValidationException(Exception exception)
        {
            var customerValidationException = new CustomerValidationException(exception);

            return customerValidationException;
        }

        private CustomerServiceException CreateAndLogServiceException(Exception exception)
        {
            var customerServiceException = new CustomerServiceException(exception);

            return customerServiceException;
        }
    }
}
