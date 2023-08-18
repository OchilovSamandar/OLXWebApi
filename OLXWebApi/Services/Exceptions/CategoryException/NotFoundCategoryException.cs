namespace OLXWebApi.Services.Exceptions.CategoryException
{
    public class NotFoundCategoryException : Exception
    {
        public NotFoundCategoryException() : base(message: "Bunday category mavjud emas") { }
    }
}
