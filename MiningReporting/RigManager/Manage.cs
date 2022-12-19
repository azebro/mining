using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RigManager
{
    public class Manage : IManageRig
    {
        
        public bool Restart(string rig)
        {
            Trace.WriteLine("Restart request received");
        }

        public object ReportStatus(string rig)
        {
            throw new NotImplementedException();
        }

        public bool ChangeSettigns(string rig, Dictionary<string, object> settigns)
        {
            throw new NotImplementedException();
        }
    }
}
