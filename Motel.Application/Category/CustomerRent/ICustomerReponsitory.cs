using Microsoft.Extensions.Caching.Distributed;
using Motel.Application.Category.CustomerRent.Dtos;
using Motel.EntityDb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.CustomerRent
{
    public interface ICustomerReponsitory
    {
        Task<CustomerRequest> GetOrSetValueAsync(string key, Func<Task<CustomerRequest>> valueDelegate, DistributedCacheEntryOptions option = null);
        Task<bool> IsValueCacheAsync(string key);
        Task RemoveCacheAsync(String key);
        Task SetValueAsync(String key, CustomerRequest value, DistributedCacheEntryOptions option = null);
    }
}
