using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CardMeasure
    {
        public int CardIndex { get; set; }
        public float Temperature { get; set; }
        public float FanPercent { get; set; }
        public float FanSpeed { get; set; }
        public float Hashrate { get; set; }
        public float WorkUnits { get; set; }
        public float RejectRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsSick { get; set; }
        public bool IsDead { get; set; }
    }
}
