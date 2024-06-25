namespace DatingApp.Errors
{
    public class APIException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public APIException(int statusCode, string message, string detail)
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
        }

       

    }
}
