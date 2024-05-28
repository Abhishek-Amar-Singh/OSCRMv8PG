using DB.Models.OSCRM;
using OSCRM.Web.Api.Models.Categories;
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
            CustomerIsNullThrowEx(dto);

            var cust = await this._storageRepo.SelectCustomerAsync(dto.email_address);

            CustomerAlreadyExistsThrowEx(cust, dto.email_address);

            cust = new()
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

            var storageCity = this._storageRepo.Select<Category>(dto.city_id);
            CategoryIsNullThrowEx(storageCity, CategoryEnum.CITY);
            VerifyParentCategory(storageCity!, CategoryEnum.CITY);

            var storageProfession = this._storageRepo.Select<Category>(dto.profession_id);
            CategoryIsNullThrowEx(storageProfession, CategoryEnum.PROFESSION);
            VerifyParentCategory(storageProfession!, CategoryEnum.PROFESSION);

            Customer storageCustomer = await this._storageRepo.InsertAsync(cust);

            return new DisplayCustomer()
            {
                id = storageCustomer.id,
                first_name = storageCustomer.first_name,
                middle_name = storageCustomer.middle_name,
                last_name = storageCustomer.last_name,
                email_address = storageCustomer.email_address,
                mobile_number = storageCustomer.mobile_number,
                city = storageCity!.name,
                city_id = storageCustomer.city_id,
                profession = storageProfession!.name,
                profession_id = storageCustomer.profession_id,
                pan_number = storageCustomer.pan_number,
            };
        });

        public IQueryable<DisplayCustomer> RetrieveAllCustomers() =>
        TryCatch(() =>
        {
            //return this._storageRepo.SelectAll<Customer>()
            //    .Select(customer => new DisplayCustomer
            //    {
            //        id = customer.id,
            //        first_name = customer.first_name,
            //        middle_name = customer.middle_name,
            //        last_name = customer.last_name,
            //        email_address = customer.email_address,
            //        mobile_number = customer.mobile_number,
            //        city = this._storageRepo.Select<Category>(customer.city_id)!.name,
            //        city_id = customer.city_id,
            //        profession = this._storageRepo.Select<Category>(customer.profession_id)!.name,
            //        profession_id = customer.profession_id,
            //        pan_number = customer.pan_number
            //    });

            return from customer in this._storageRepo.SelectAll<Customer>()
                   join cityCategory in this._storageRepo.SelectAll<Category>() on customer.city_id equals cityCategory.id
                   join professionCategory in this._storageRepo.SelectAll<Category>() on customer.profession_id equals professionCategory.id
                   select new DisplayCustomer
                   {
                       id = customer.id,
                       first_name = customer.first_name,
                       middle_name = customer.middle_name,
                       last_name = customer.last_name,
                       email_address = customer.email_address,
                       mobile_number = customer.mobile_number,
                       city = cityCategory.name,
                       city_id = customer.city_id,
                       profession = professionCategory.name,
                       profession_id = customer.profession_id,
                       pan_number = customer.pan_number
                   };
        });
    }
}
