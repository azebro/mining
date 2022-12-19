using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StatsParser
{
    internal class WafflePoolStats
    {
        [DataContract]
        public class Rootobject
        {
            [DataMember]
            public Class1[] Property1 { get; set; }
        }

        [DataContract]
        public class Class1
        {
            [DataMember]
            public float earned { get; set; }
            [DataMember]
            public float hashrate { get; set; }
            [DataMember]
            public float permhs { get; set; }
        }


    }




}
