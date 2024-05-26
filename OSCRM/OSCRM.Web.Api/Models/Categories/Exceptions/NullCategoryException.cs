namespace OSCRM.Web.Api.Models.Categories.Exceptions
{
    public class NullCategoryException : Exception
    {
        public NullCategoryException(string name) : base(message: $"The category under parent category '{name}' is null.") { }
    }
}
