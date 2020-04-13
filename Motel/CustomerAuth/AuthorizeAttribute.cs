using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.CustomerAuth
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute( params string[] claim) : base(typeof(AuthorizeAttribute))
        {
            Arguments = new object[] { claim };
        }
    }
}
