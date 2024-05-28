using Npgsql;
using OSCRM.Web.Api.Models.Categories.Exceptions;
using OSCRM.Web.Api.Models.Customers.Exceptions;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public partial class CustomerService
    {
        private delegate ValueTask<T> ReturningAsyncFunction<T>();
        private delegate IQueryable<T> ReturningFunction<T>();

        private async ValueTask<T> TryCatch<T>(ReturningAsyncFunction<T> returningAsyncFunction)
        {
            try
            {
                return await returningAsyncFunction();
            }
            catch (InvalidCustomerException invalidCustException)
            {
                throw CreateAndLogValidationException(invalidCustException);
            }
            catch (NullCustomerException nullCustomerException)
            {
                throw CreateAndLogValidationException(nullCustomerException);
            }
            catch (AlreadyExistsCustomerException alreadyExistsCustException)
            {
                throw CreateAndLogValidationException(alreadyExistsCustException);
            }
            catch (NullCategoryException nullCategoryException)
            {
                throw CreateAndLogValidationException(nullCategoryException);
            }
            catch (FailedToVerifyCategoryException failedToVerifyCategoryException)
            {
                throw CreateAndLogValidationException(failedToVerifyCategoryException);
            }
            catch (NpgsqlException npgsqlException)
            {
                throw CreateAndLogSqlException(npgsqlException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private IQueryable<T> TryCatch<T>(ReturningFunction<T> returningFunction)
        {
            try
            {
                return returningFunction();
            }
            catch (NpgsqlException npgsqlException)
            {
                throw CreateAndLogSqlException(npgsqlException);
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
        
        private CustomerSqlException CreateAndLogSqlException(Exception exception)
        {
            var customerSqlException = new CustomerSqlException(exception);

            return customerSqlException;
        }

        private CustomerServiceException CreateAndLogServiceException(Exception exception)
        {
            var customerServiceException = new CustomerServiceException(exception);

            return customerServiceException;
        }
    }
}
