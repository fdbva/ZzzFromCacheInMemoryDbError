using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Z.EntityFramework.Plus;

namespace FakeData
{
    public class FakeContext : DbContext
    {
        public DbSet<FakeModel> FakeModels { get; set; }

        public FakeContext(DbContextOptions<FakeContext> options) : base(options)
        {
            QueryCacheManager.DefaultMemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };
        }
    }
}