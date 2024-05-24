using OSCRM.Web.Api.Models.Customers;
using Shared.Lib.Models;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public interface ICustomerService
    {
        ValueTask<DisplayCustomer> CreateCustomerAsync(CreateCustomer dto);
    }
}
