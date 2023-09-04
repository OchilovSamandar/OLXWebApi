using System.Runtime.Serialization;

namespace OLXWebApi.Services.Exceptions
{
    
    public class OlxWebApiException : Exception
    {
        public int Status { get; set; }
        public OlxWebApiException(int status = 500, string message = "Something went wrong") :base(message) {
        
           this.Status = status;
        
        }

    }
}