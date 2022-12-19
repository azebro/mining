using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using DataAccess;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using StatsParser;


namespace PoolDataCollector
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("PoolDataCollector entry point called", "Information");

            while (true)
            {
                
                Trace.TraceInformation("Working", "Information");
                var client = new ParseIndividualStats();
                var poolsStats = new ParsePoolStats();
                var response = client.ParseWorkers();
                var poolResponse = poolsStats.LoadFromApi();
                var upload = new SampleUpload();
                upload.UploadWorkerStats(response);
                upload.UploadPoolStats(poolResponse);
                Trace.TraceInformation("Work complete, going to sleep", "Information");
                Thread.Sleep(120000);
                
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
