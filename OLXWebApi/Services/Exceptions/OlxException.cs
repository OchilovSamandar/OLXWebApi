namespace OLXWebApi.Services.Exceptions
{
    public class OlxException : Exception
    {
        public int Code { get; set; }

        public OlxException(int code = 500, string message = "Somthing went wrong") : base(message)
        {
            this.Code = code;
        }
    }
}
