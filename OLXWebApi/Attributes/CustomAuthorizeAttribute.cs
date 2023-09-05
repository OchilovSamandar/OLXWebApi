using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using OLXWebApi.Models;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.IService;
using System.Security.Claims;

namespace OLXWebApi.Attributes
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(): base(typeof(CustomAuthorizeAttributeFilter)) { }


        public class CustomAuthorizeAttributeFilter : IAuthorizationFilter
        {
            private readonly IRolePermissionService _rolePermissionService;

            public CustomAuthorizeAttributeFilter(IRolePermissionService rolePermissionService)
            {
                _rolePermissionService = rolePermissionService;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
               var controllerDescripter = context.ActionDescriptor as ControllerActionDescriptor;
               var result = controllerDescripter.ControllerName + "." + controllerDescripter.ActionName;
               var role = context.HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role).Value ?? string.Empty;
               var res =  _rolePermissionService.CheckPermission(role, result).GetAwaiter().GetResult();

                if(!res)
                {
                    var exception = new OlxWebApiException(403, "you don't have permission for this method");
                    context.Result = new ObjectResult(new Response
                    {
                        Status = exception.Status,
                        Message = exception.Message,
                    })
                    {
                        StatusCode = exception.Status
                    };
                }

            }
        }
    }

    
}
