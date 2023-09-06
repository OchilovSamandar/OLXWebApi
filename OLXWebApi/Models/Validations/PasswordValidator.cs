using System.Runtime.CompilerServices;

namespace OLXWebApi.Models.Validations
{
    public static class PasswordValidator
    {
        public static (bool isValid , string Message) IsStrong(string passowrd)
        {
            bool isDigit = passowrd.Any(x => char.IsDigit(x));
            if (!isDigit)
                return (false, "Password must contain at least 1 digit nummber");
            bool isUppercase = passowrd.Any(x=> char.IsUpper(x));
            if (!isUppercase)
                return (false, "Password must contain at least 1 uppercase character");

            return (true, "Valid password");
        }
    }
}
