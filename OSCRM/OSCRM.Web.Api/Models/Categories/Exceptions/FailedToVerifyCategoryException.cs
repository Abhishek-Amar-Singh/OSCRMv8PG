namespace OSCRM.Web.Api.Models.Categories.Exceptions
{
    public class FailedToVerifyCategoryException : Exception
    {
        public FailedToVerifyCategoryException(string name, string parent_name)
            : base(message: $"Category '{name}' is not under parent category '{parent_name}'.") { }
    }
}
