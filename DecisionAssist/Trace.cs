//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecisionAssist
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trace
    {
        public int Trace_id { get; set; }
        public int DD_it { get; set; }
        public Nullable<int> FR_id { get; set; }
        public Nullable<int> Dc_id { get; set; }
    
        public virtual DesignDecision DesignDecision { get; set; }
    }
}