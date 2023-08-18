namespace OLXWebApi.Services.Exceptions.UserExceptions
{
    public class EmailOrPasswordIncorrectException : Exception
    {
        public EmailOrPasswordIncorrectException() : base(message: "Email or Password incorrect") { }
    }
}
