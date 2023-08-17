using System.Runtime.Serialization;

namespace OLXWebApi.Services.Exceptions
{
    [Serializable]
    internal class EmailAlreadyTakenException : Exception
    {
        public EmailAlreadyTakenException(string email) : base(message:$"This email already taken {email}")
        {
        }

    }
}