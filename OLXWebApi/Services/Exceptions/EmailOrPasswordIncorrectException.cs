namespace OLXWebApi.Services.Exceptions
{
    public class EmailOrPasswordIncorrectException :Exception
    {
        public EmailOrPasswordIncorrectException() :base(message:"Email or Password incorrect") { }
    }
}
