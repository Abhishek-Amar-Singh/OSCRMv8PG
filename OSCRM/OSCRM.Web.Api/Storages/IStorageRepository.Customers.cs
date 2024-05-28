using DB.Models.OSCRM;

namespace OSCRM.Web.Api.Storages
{
    public partial interface IStorageRepository
    {
        ValueTask<Customer?> SelectCustomerAsync(string email);
    }
}
