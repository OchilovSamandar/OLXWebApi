using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OLXWebApi.Attributes
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(): base(typeof(CustomAuthorizeAttributeFilter)) { }


        public class CustomAuthorizeAttributeFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                throw new NotImplementedException();
            }
        }
    }

    
}
