//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PoolWorkerReading
    {
        public long RowId { get; set; }
        public System.Guid ReadingId { get; set; }
        public string Worker { get; set; }
        public double Hashrate { get; set; }
        public System.DateTime LastSeen { get; set; }
        public double StaleRate { get; set; }
    
        public virtual PoolReading PoolReading { get; set; }
    }
}
