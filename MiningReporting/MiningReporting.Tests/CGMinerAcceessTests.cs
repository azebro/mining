using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Collector.Tests
{
    [TestClass()]
    public class CGMinerAcceessTests
    {
        [TestMethod()]
        public void QueryCGMinerTest()
        {
            var cgMiner = new CGMinerAcceess();
           // cgMiner.QueryCGMiner();
            Assert.Fail();
        }

        [TestMethod()]
        public void CollectHashDataTest()
        {
            var collector = new DataCollector();
            collector.CollectHashData("192.168.0.168", 4028, "Rig9", 9);
            Assert.IsTrue(true);
        }
    }
}
