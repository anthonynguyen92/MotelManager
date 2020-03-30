using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.ViewModel.System.User
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
