using Newtonsoft.Json;

namespace HotelManager.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public required IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
