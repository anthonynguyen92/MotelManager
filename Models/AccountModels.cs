using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModels
    {
        private MotelDBcontext _context = null;

        public AccountModels()
        {
            _context = new MotelDBcontext();
        }
        public bool Login(String username,string password)
        {
            var valuecheck = _context.Accounts.FirstOrDefault(m => m.UserName == username);
            if (valuecheck.Password == username)
                return true;
            return false;
        }
    }
}
