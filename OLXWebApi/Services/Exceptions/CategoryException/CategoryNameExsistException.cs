namespace OLXWebApi.Services.Exceptions.CategoryException
{
    public class CategoryNameExsistException : Exception
    {
       public CategoryNameExsistException(string name) : base(message:$"bunday category name mavjud:{name}") { }
    }
}
