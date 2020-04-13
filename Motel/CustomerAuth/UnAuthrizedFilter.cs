using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.CustomerAuth
{
    public class UnAuthrizedFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isauthentication = context.HttpContext.User.Identity.IsAuthenticated;
            if (!isauthentication)
            {
                context.Result = new RedirectResult("/Manage/Login");
            }
        }
    }
}
