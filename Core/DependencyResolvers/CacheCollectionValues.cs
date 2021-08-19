using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

namespace Core.DependencyResolvers
{
    public static class CacheCollectionValues
    {
        public static List<ICacheEntry> AllKey(IMemoryCache cahce)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(cahce) as dynamic;


            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {

                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);


                cacheCollectionValues.Add(cacheItemValue);
            }

            return cacheCollectionValues;
        }
    }
}
