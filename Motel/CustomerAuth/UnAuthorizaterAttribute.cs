using Microsoft.AspNetCore.Mvc;

namespace Motel.CustomerAuth
{
    public class UnAuthorizaterAttribute : TypeFilterAttribute
    {
        public UnAuthorizaterAttribute() : base(typeof(UnAuthorizaterAttribute))
        {
        }
    }
}
