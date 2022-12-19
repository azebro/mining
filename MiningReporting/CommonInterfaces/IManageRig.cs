using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IManageRig
    {
        bool Restart(string rig);
        object ReportStatus(string rig);
        bool ChangeSettigns(string rig, Dictionary<string, object> settigns);
    }
}
