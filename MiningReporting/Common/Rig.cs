using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Rig
    {
        public string RigName { get; set; }
        public float Hashrate { get; set; }
        public float StaleRate { get; set; }
        public DateTime LastSeen { get; set; }
    }
}
