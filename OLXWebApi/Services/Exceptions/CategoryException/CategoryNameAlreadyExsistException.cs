namespace OLXWebApi.Services.Exceptions.CategoryException
{
    public class CategoryNameAlreadyExsistException : Exception
    {
        public CategoryNameAlreadyExsistException(string name) : base(message:$"Bunday nameli category mavjud")
        {

        }
    }
}
