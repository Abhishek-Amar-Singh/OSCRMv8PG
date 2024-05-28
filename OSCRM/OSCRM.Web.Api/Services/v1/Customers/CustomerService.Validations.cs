using DB.Models.OSCRM;
using OSCRM.Web.Api.Models.Categories;
using OSCRM.Web.Api.Models.Categories.Exceptions;
using OSCRM.Web.Api.Models.Customers;
using OSCRM.Web.Api.Models.Customers.Exceptions;
using Shared.Lib.Models;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public partial class CustomerService
    {
        private void CustomerAlreadyExistsThrowEx(Customer? cust, string email)
        {
            if (cust is not null)
            {
                throw new AlreadyExistsCustomerException(email);
            }
        }

        private void CustomerIsNullThrowEx(CreateCustomer dto)
        {
            if (dto is null)
            {
                throw new NullCustomerException();
            }
        }

        private void CategoryIsNullThrowEx(Category? category, CategoryEnum num)
        {
            if (category is null)
            {
                category = this._storageRepo.Select<Category>((long)num);

                throw new NullCategoryException(category!.name);
            }
        }

        private void VerifyParentCategory(Category category, CategoryEnum num)
        {
            if (category.parent_category_id != (long)num)
            {
                var _category = this._storageRepo.Select<Category>((long)num);

                throw new FailedToVerifyCategoryException(category.name, _category!.name);
            }
        }
    }
}
