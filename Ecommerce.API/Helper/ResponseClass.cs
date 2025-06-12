namespace Ecommerce.API.Helper
{
    public class ResponseClass
    {
         public string Message { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; } = null;
        public ResponseClass(int StatusCode, string message=null, object? data = null)
        {
            StatusCode = StatusCode;
            Message = Message?? GetMessageFromStatusCode(StatusCode);
            Data = data;
        }
        string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Created",
                204 => "No Content",
                302 => "Found",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status"
            };
        }   
    }
}
