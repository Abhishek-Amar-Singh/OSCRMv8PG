using DB.Models.OSCRM;
using Microsoft.EntityFrameworkCore;

namespace OSCRM.Web.Api.Storages
{
    public partial class StorageRepository
    {
        public async ValueTask<Customer?> SelectCustomerAsync(string email) =>
            await this._context.customerTbl.FirstOrDefaultAsync(x => x.email_address == email);
    }
}
