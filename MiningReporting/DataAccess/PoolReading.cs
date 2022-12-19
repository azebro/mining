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
    
    public partial class PoolReading
    {
        public PoolReading()
        {
            this.Balances = new HashSet<Balance>();
            this.PoolWorkerReadings = new HashSet<PoolWorkerReading>();
        }
    
        public long RowId { get; set; }
        public System.Guid ReadingId { get; set; }
        public double Reading { get; set; }
        public System.DateTime Time { get; set; }
        public int Pool { get; set; }
        public string Error { get; set; }
    
        public virtual ICollection<Balance> Balances { get; set; }
        public virtual Pool Pool1 { get; set; }
        public virtual ICollection<PoolWorkerReading> PoolWorkerReadings { get; set; }
    }
}
