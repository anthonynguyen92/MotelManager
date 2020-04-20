using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace Motel.Utilities.CacheTagHelper
{
    public class MemoryCacheHelper
    {
        public static object getValue(string key) => MemoryCache.Default.Get(key);

        public static bool Add(String key, object value, DateTimeOffset date) => MemoryCache.Default.Add(key, value, date);

        public static void Delete(string key)
        {
            MemoryCache memory = MemoryCache.Default;
            if (memory.Contains(key))
                memory.Remove(key);
        }
    }
}
