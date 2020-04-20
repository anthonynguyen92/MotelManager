using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Motel.Utilities.Reponsitory
{
    public abstract class DistributedCacheRepository<T> : IDistributedCacheReponsitory<T> where T : class
    {
        private readonly IDistributedCache _distributedCache;
        private readonly string _keyPrefix;

        protected DistributedCacheRepository(IDistributedCache cache,string keyPrefix)
        {
            _distributedCache = cache;
            _keyPrefix = keyPrefix;
        }
        public virtual async Task<T> GetorSetValueAsync(string key, Func<Task<T>> valueDelegate, DistributedCacheEntryOptions options)
        {
            var value = await GetValueAsync(key);
            if(value == null)
            {
                value = await valueDelegate();
                if (value == null)
                    await SetValueAsync(key, value, options ?? GetDefaultOptions());
            }
            return null;
        }

        public async Task<T> GetValueAsync(string key)
        {
            var value = await _distributedCache.GetStringAsync(_keyPrefix + key);
            return value != null ? JsonConvert.DeserializeObject<T>(value) : null;
        }

        public async Task<bool> IsValueCacheAsync(string key)
        {
            var value = await _distributedCache.GetStringAsync(_keyPrefix + key);
            return value != null;
        }

        public async Task RemoveValueAsync(string key) => await _distributedCache.RemoveAsync(_keyPrefix +key);


        public async Task SetValueAsync(string key, T value, DistributedCacheEntryOptions option)
        {
            await _distributedCache.SetStringAsync(_keyPrefix + key, JsonConvert.SerializeObject(value), option ?? GetDefaultOptions());
        }

        protected abstract DistributedCacheEntryOptions GetDefaultOptions();
    }
}
