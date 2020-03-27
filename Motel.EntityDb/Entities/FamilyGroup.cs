using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Motel.EntityDb.Entities
{
    public class FamilyGroup
    {
        public string  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Identification { get; set; }
        public string User { get; set; }
        public Customer Customers { get; set; }
    }
}
