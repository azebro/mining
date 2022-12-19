using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Collector;
using System.Diagnostics;

    
namespace CollectorService
{
    public partial class Collector : ServiceBase
    {
       
    
        private readonly ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private Thread _thread;
        public Collector()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Trace.WriteLine("Service Starting...");
            _thread = new Thread(_ =>
            {
                var cgMiner = new CGMinerAcceess();
                while (!_shutdownEvent.WaitOne(0))
                {
                   
                    Trace.WriteLine("Calling CGMiner...");
                    try
                    {
                        cgMiner.QueryCGMiner("192.168.0.171", 4028, 7);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine("CGMiner call error: " + e.ToString());
                    }
                    Trace.WriteLine("Sleeping...");
                    Thread.Sleep(10000);
                }
            }) {Name = "My Worker Thread", IsBackground = true};
            _thread.Start();


        }

      


        protected override void OnStop()
        {
            Trace.WriteLine("Service stopping...");
            _shutdownEvent.Set();
            if (!_thread.Join(3000))
            { // give the thread 3 seconds to stop
                _thread.Abort();
            }

            
        }
    }
}
