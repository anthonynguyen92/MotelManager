using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Utilities.Helper
{
    public interface ISelfHttpClient
    {
        Task PostIdAsync(string apiRoute, string id);
    }
}
