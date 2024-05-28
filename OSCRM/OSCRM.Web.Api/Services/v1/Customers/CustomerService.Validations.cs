using DB.Models.OSCRM;
using OSCRM.Web.Api.Models.Categories;
using OSCRM.Web.Api.Models.Categories.Exceptions;
using OSCRM.Web.Api.Models.Customers;
using OSCRM.Web.Api.Models.Customers.Exceptions;
using Shared.Lib.Models;
using System.Text.RegularExpressions;

namespace OSCRM.Web.Api.Services.v1.Customers
{
    public partial class CustomerService
    {
        private void CustomerIsNullThrowEx(CreateCustomer dto)
        {
            if (dto is null)
            {
                throw new NullCustomerException();
            }
        }

        private void ValidateCustomerPropertiesOnCreate(Customer cust)
        {
            Validate(
                (Rule: IsInvalidNameRegEx(cust.first_name), Parameter: nameof(Customer.first_name)),
                (Rule: IsInvalidNameRegEx(cust.last_name), Parameter: nameof(Customer.last_name)),
                (Rule: IsInvalidEmailRegEx(cust.email_address), Parameter: nameof(Customer.email_address)),
                (Rule: IsInvalidMobileRegEx(cust.mobile_number), Parameter: nameof(Customer.mobile_number)),
                (Rule: IsInvalidX(cust.city_id), Parameter: nameof(Customer.city_id)),
                (Rule: IsInvalidX(cust.profession_id), Parameter: nameof(Customer.profession_id)),
                (Rule: IsInvalidPANRegEx(cust.pan_number), Parameter: nameof(Customer.pan_number))
            );

            if (cust.middle_name is not null)
            {
                Validate(
                    (Rule: IsInvalidNameRegEx(cust.middle_name), Parameter: nameof(Customer.middle_name))
                );
            }
        }

        private void CustomerAlreadyExistsThrowEx(Customer? cust, string email)
        {
            if (cust is not null)
            {
                throw new AlreadyExistsCustomerException(email);
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

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    throw new InvalidCustomerException(rule.Message, parameter);
                }
            }
        }

        //private dynamic IsInvalidX(string text) => new
        //{
        //    Condition = String.IsNullOrWhiteSpace(text),
        //    Message = new string[] { "Text is required" }
        //};

        private dynamic IsInvalidX(long input) => new
        {
            Condition = input == default,
            Message = new string[] { $"'{input}' is invalid" }
        };

        private dynamic IsInvalidNameRegEx(string text) => new
        {
            Condition = !new Regex("^[A-Za-z'-]+$").IsMatch(text),
            Message = new string[]
            {
                "Text format is not correct",
                $"To rectify:\\n1) Should contain one or more occurrences of the following characters: Uppercase letters(A - Z), Lowercase letters(a - z), Single quote('), Hyphen(-), etc..\\n2) Should contain only 1 whitespace."
            }
        };

        private dynamic IsInvalidEmailRegEx(string email)
        {
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return new
            {
                Condition = !new Regex(pattern).IsMatch(email),
                Message = new string[]
                {
                    "Email Address format is incorrect",
                    $"To rectify:\\n1) Should begin with any combination of letters (both uppercase and lowercase), numbers, dots, underscores, percent signs, plus signs, or hyphens.\\n2) After the initial characters, there must be an \"at\" symbol (@).\\n3) Following the \"@\" symbol, there should be more letters, numbers, dots, or hyphens in the domain name.\\n4) After the domain name, there must be a dot (.).\\n5) After the dot, there should be at least two letters. This represents the top-level domain (like .com, .org, .net)."
                }
            };
        }

        private dynamic IsInvalidMobileRegEx(string mobile) => new
        {
            Condition = !new Regex("^\\d{10}$").IsMatch(mobile),
            Message = new string[]
            {
                "Mobile Number format is not correct"
            }
        };

        private dynamic IsInvalidPANRegEx(string pan) => new
        {
            Condition = !new Regex("^[A-Z]{5}[0-9]{4}[A-Z]$").IsMatch(pan),
            Message = new string[] { $"PAN is incorrect" }
        };
    }
}
