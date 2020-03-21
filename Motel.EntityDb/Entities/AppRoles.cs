using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class AppRoles :IdentityRole<Guid>
    {
        public String Descriptions { get; set; }
    }
}
