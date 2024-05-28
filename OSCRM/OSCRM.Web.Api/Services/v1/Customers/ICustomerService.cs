using OSCRM.Web.Api.Models.Customers;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public interface ICustomerService
    {
        ValueTask<DisplayCustomer> CreateCustomerAsync(CreateCustomer dto);
        IQueryable<DisplayCustomer> RetrieveAllCustomers();
    }
}
