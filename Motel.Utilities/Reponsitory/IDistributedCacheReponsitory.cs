using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Utilities.Reponsitory
{
    public interface IDistributedCacheReponsitory<T>
    {
        Task<T> GetorSetValueAsync(string key, Func<Task<T>> valueDelegate, DistributedCacheEntryOptions options);
        Task<bool> IsValueCacheAsync(string key);
        Task<T> GetValueAsync(string key);
        Task SetValueAsync(string key, T value, DistributedCacheEntryOptions option);
        Task RemoveValueAsync(string key);
    }
}
