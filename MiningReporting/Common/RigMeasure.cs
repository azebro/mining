using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RigMeasure
    {
        public String RigName { get; set; }
        public float HashRate { get; set; }
        public float RejectRate { get; set; }
        public float WorkUnits { get; set; }
        public DateTime CollectedOn { get; set; }
        public DateTime RunningFrom { get; set; }
        public int HardwareErrors { get; set; }
        public IList<CardMeasure> CardMeasures { get; set; }



    }
}
