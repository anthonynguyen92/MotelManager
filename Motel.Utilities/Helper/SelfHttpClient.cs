using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Utilities.Helper
{
    public class SelfHttpClient : ISelfHttpClient
    {
        private readonly HttpClient _client;
        public SelfHttpClient(HttpClient client , IHttpContextAccessor httpContextAccessor) 
        {
            string baseString = 
        }
        public Task PostIdAsync(string apiRoute, string id)
        {
            throw new NotImplementedException();
        }

    }
}
