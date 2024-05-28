
namespace Shared.Lib.Models
{
    public class Response<T> where T : class
    {
        public int status { get; set; } = 200;
        public string message { get; set; } = "success";
        public T? data { get; set; }
    }
}
