using System.Net;

namespace PHRecord.Models.DTO
{
    public class ResponseDTO
    {
        public object info { get; set; }
        public object data { get; set; }
        public HttpStatusCode status { get; set; }  //OK = 200, Created = 201, NoContent = 204, BadRequest = 400, Unauthorized = 401, Forbidden = 403, NotFound = 404
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
