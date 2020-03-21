using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
