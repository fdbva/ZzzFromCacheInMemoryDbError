using System;
using System.Linq;
using FakeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.EntityFramework.Plus;

namespace FakeTest
{
    [TestClass]
    public class FakeIntegrationTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FakeContext>();
            optionsBuilder.UseInMemoryDatabase("testName")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            var fakeContext = new FakeContext(optionsBuilder.Options);
            QueryCacheManager.UseFirstTagAsCacheKey = true;

            fakeContext.Add(new FakeModel { FakeId = Guid.NewGuid(), FakeString = "fakeString" });

            var fakeModels = fakeContext
                .FakeModels
                .FromCache(typeof(FakeModel).Name)
                .ToList();
        }
    }
}