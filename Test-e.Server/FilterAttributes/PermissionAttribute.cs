using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Test_e.Server.FilterAttributes
{
    public sealed class PermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _requiredPermission;

        public PermissionAttribute(string requiredPermission)
        {
            _requiredPermission = requiredPermission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity?.IsAuthenticated ?? true)
            {
                context.Result = new JsonResult(new
                {
                    status = 401,
                    message = "User is not authenticated. Please log in."
                })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }

            var hasPermission = user.Claims.Any(c => c.Type == "permission" && c.Value == _requiredPermission);
            if (!hasPermission)
            {
                context.Result = new JsonResult(new
                {
                    status = 403,
                    message = $"User is not authorized to this request. Missing required permission: {_requiredPermission}"
                })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }

}
