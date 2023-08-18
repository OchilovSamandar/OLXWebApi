using System.Runtime.Serialization;

namespace OLXWebApi.Services.Exceptions.UserExceptions
{
    [Serializable]
    internal class EmailAlreadyTakenException : Exception
    {
        public EmailAlreadyTakenException(string email) : base(message: $"This email already taken {email}")
        {
        }

    }
}