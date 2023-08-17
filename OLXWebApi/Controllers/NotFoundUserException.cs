using System.Runtime.Serialization;

namespace OLXWebApi.Controllers
{
    [Serializable]
    internal class NotFoundUserException : Exception
    {
        public NotFoundUserException(long id) : base(message:$"Bunday user mavjud emas: {id}")
        {
        }

        
    }
}