using DB.Models.OSCRM;
using OSCRM.Web.Api.Models.Customers;
using OSCRM.Web.Api.Storages;
using Shared.Lib.Extensions;
using Shared.Lib.Models;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public partial class CustomerService : ICustomerService
    {
        private readonly IStorageRepository _storageRepo;

        public CustomerService(IStorageRepository _storageRepo) =>
            this._storageRepo = _storageRepo;

        public ValueTask<DisplayCustomer> CreateCustomerAsync(CreateCustomer dto) =>
        TryCatch(async () =>
        {
            Customer cust = new()
            {
               first_name = dto.first_name.ToTitleCase(),
               middle_name = dto.middle_name is null ? null : dto.middle_name.ToTitleCase(),
               last_name = dto.last_name.ToTitleCase(),
               email_address = dto.email_address.ToLowerCase(),
               mobile_number = dto.mobile_number,
               city_id = dto.city_id,
               profession_id = dto.profession_id,
               pan_number =dto.pan_number.ToUpperCase()
            };

            var storageCustomer = await this._storageRepo.InsertAsync(cust);

            return new DisplayCustomer()
            {
                id = storageCustomer.id,
                first_name = storageCustomer.first_name,
                middle_name = storageCustomer.middle_name,
                last_name = storageCustomer.last_name,
                email_address = storageCustomer.email_address,
                mobile_number = storageCustomer.mobile_number,
                city = this._storageRepo.Select<Category>(storageCustomer.city_id)!.name,
                city_id = storageCustomer.city_id,
                profession = this._storageRepo.Select<Category>(storageCustomer.profession_id)!.name,
                profession_id = storageCustomer.profession_id,
                pan_number = storageCustomer.pan_number,
            };
        });
    }
}
