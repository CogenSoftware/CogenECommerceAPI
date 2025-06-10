using Newtonsoft.Json;

namespace Core.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> errors { get; set; } = new List<string>();
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class ErrorStatusCode
    {
        public int statusCode { get; set; }
    }
}