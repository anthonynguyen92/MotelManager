using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Motel.Application.Category.CustomerRent.Dtos;
using Motel.Utilities.Reponsitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.CustomerRent
{
    public class CustomerCacheReponsitory : DistributedCacheRepository<CustomerRequest>, ICustomerReponsitory
    {
        private const string KeyPrefix = "Customer:";
        private readonly CustomerSettings _setting;
        public CustomerCacheReponsitory(IDistributedCache cache, IOptions<CustomerSettings> settings) : base(cache, KeyPrefix)
        {
            _setting = settings.Value;
        }

        public Task RemoveCacheAsync(string key)
        {
            return base.RemoveValueAsync(key);
        }

        public Task SetValueAsync(string key, CustomerRequest value, DistributedCacheEntryOptions option = null)
        {
            return base.SetValueAsync(key, value, option);
        }

        protected override DistributedCacheEntryOptions GetDefaultOptions()
        {
            return new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_setting.CatchingExpirationPeriod),
            };
        }

        public async Task<CustomerRequest> GetOrSetValueAsync(string key, Func<Task<CustomerRequest>> valueDelegate, DistributedCacheEntryOptions option = null)
        {
            return await base.GetorSetValueAsync(key,valueDelegate,option);
        }
    }
}
