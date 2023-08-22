namespace OLXWebApi.Shared.Helper
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor { get; set; }
        public static HttpContext HttpContext => Accessor?.HttpContext;
        public static string UserRole => HttpContext?.User?.FindFirst("Role")?.Value;
        public static long? UserId => long.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;

        private static long _tempUserId;
    }
}
