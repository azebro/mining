using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Payment
    {
        public float Amount { get; set; }
        
        public DateTime When { get; set; }
        
        public string TxId { get; set; }
    }
}
