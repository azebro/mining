using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Collector
{
    
    internal class CGMinerSummary
    {
        [DataContract]
        public class Rootobject
        {
            [DataMember]
            public STATUS[] STATUS { get; set; }
            [DataMember]
            public SUMMARY[] SUMMARY { get; set; }
            [DataMember]
            public int id { get; set; }
        }

        [DataContract]
        public class STATUS
        {
            [DataMember(Name = "STATUS")]
            public string Status { get; set; }
            [DataMember]
            public int When { get; set; }
            [DataMember]
            public int Code { get; set; }
            [DataMember]
            public string Msg { get; set; }
            [DataMember]
            public string Description { get; set; }
        }
        [DataContract]
        public class SUMMARY
        {
            [DataMember]
            public int Elapsed { get; set; }
            [DataMember(Name = "MHS av")]
            public float MHSav { get; set; }
            [DataMember(Name = "MHS 5s")]
            public float MHS5s { get; set; }
            [DataMember(Name = "Found Blocks")]
            public int FoundBlocks { get; set; }
            [DataMember]
            public int Getworks { get; set; }
            [DataMember]
            public int Accepted { get; set; }
            [DataMember]
            public int Rejected { get; set; }
            [DataMember(Name = "Hardware Errors")]
            public int HardwareErrors { get; set; }
            [DataMember]
            public float Utility { get; set; }
            [DataMember]
            public int Discarded { get; set; }
            [DataMember]
            public int Stale { get; set; }
            [DataMember(Name = "Get Failures")]
            public int GetFailures { get; set; }
            [DataMember(Name = "Local Work")]
            public int LocalWork { get; set; }
            [DataMember(Name = "Remote Failures")]
            public int RemoteFailures { get; set; }
            [DataMember(Name = "Network Blocks")]
            public int NetworkBlocks { get; set; }
            [DataMember(Name = "Total MH")]
            public float TotalMH { get; set; }
            [DataMember(Name = "Work Utility")]
            public float WorkUtility { get; set; }
            [DataMember(Name = "Difficulty Accepted")]
            public float DifficultyAccepted { get; set; }
            [DataMember(Name = "Difficulty Rejected")]
            public float DifficultyRejected { get; set; }
            [DataMember(Name = "Difficulty Stale")]
            public float DifficultyStale { get; set; }
            [DataMember(Name = "Best Share")]
            public int BestShare { get; set; }
            [DataMember(Name = "Device Hardware%")]
            public float DeviceHardware { get; set; }
            [DataMember(Name = "Device Rejected%")]
            public float DeviceRejected { get; set; }
            [DataMember(Name = "Pool Rejected%")]
            public float PoolRejected { get; set; }
            [DataMember(Name = "Pool Stale%")]
            public float PoolStale { get; set; }
        }

    }
}
