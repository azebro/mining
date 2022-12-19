using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StatsParser
{
    internal class IndividualStatsApi
    {
        [DataContract]
        public class Rootobject
        {
            [DataMember]
            public int hash_rate { get; set; }

            [DataMember]
            public string hash_rate_str { get; set; }

            [DataMember]
            public Worker_Hashrates[] worker_hashrates { get; set; }

            [DataMember]
            public Balances balances { get; set; }

            [DataMember]
            public Recent_Payments[] recent_payments { get; set; }

            [DataMember]
            public string error { get; set; }
        }

        [DataContract]
        public class Balances
        {
            [DataMember]
            public float sent { get; set; }
            [DataMember]
            public float confirmed { get; set; }
            [DataMember]
            public float unconverted { get; set; }
        }

        [DataContract]
        public class Worker_Hashrates
        {
            [DataMember]
            public string username { get; set; }
            [DataMember]
            public int hashrate { get; set; }
            [DataMember]
            public float stalerate { get; set; }
            [DataMember]
            public long last_seen { get; set; }
            [DataMember]
            public string str { get; set; }
        }

        [DataContract]
        public class Recent_Payments
        {
            [DataMember]
            public string amount { get; set; }
            [DataMember]
            public string time { get; set; }
            [DataMember]
            public string txn { get; set; }
        }


    }
}
