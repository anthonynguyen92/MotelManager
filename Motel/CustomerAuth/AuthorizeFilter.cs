using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.CustomerAuth
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        readonly string[] _claim;
        public AuthorizeFilter(string[] claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isauthen = context.HttpContext.User.Identity.IsAuthenticated;
            if (isauthen)
            {
                bool flagclaim = false;
                foreach( var item in _claim)
                    if (context.HttpContext.User.HasClaim(item, item))
                        flagclaim = true;
                if (!flagclaim)
                {
                    context.Result = new RedirectResult("/Manage");
                }
            }
            else
            {
                context.Result = new RedirectResult("/User/Login");
            }
            return;
        }
    }
}
