using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsParser;

namespace MiningReporting.Tests
{
    [TestClass]
    public class ParseIndividualStatsTests
    {
        [TestMethod]
        public void TestParse()
        {
            var client = new ParseIndividualStats();
            var response = client.ParseWorkers();
            Assert.IsNotNull(response);
        }
    }
}
