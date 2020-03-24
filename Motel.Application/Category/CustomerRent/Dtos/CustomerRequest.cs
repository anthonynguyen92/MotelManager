using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.CustomerRent.Dtos
{
    public class CustomerRequest
    {
        public string IDuser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
    }
}
