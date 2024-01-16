using System;
using System.Threading.Tasks;
using HerPortal.BusinessLogic.Models.Enums;
using HerPortal.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace HerPortal.Helpers;

public class RequiresDesnzStaffFilterAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly UserService userService;

    public RequiresDesnzStaffFilterAttribute(UserService userService)
    {
        this.userService = userService;
    }
    
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var emailAddress = context.HttpContext.User.GetEmailAddress();
        var user = await userService.GetUserByEmailAsync(emailAddress);

        if (user.Role != UserRole.DesnzStaff)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Index"
            }));
        }
    }
}