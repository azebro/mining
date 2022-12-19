using System;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsParser;

namespace MiningReporting.Tests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void SampleUpload()
        {
            var client = new ParseIndividualStats();
            var response = client.ParseWorkers();
            var upload = new SampleUpload();
            upload.UploadWorkerStats(response);
            Assert.IsTrue(true);
        }
    }
}
