using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MeasureSample
    {
        public DateTime TakenOn { get; set; }
        public DateTime ServerTime { get; set; }
        public List<Rig> Readings { get; set; }
        public float HashRate { get; set; }
        public List<Payment> Payments { get; set; }
        public Balance Balances { get; set; }

    }
}
