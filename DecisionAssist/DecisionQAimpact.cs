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
    
    public partial class DecisionQAimpact
    {
        public int Impact_id { get; set; }
        public Nullable<int> DR_id { get; set; }
        public Nullable<int> DD_id { get; set; }
        public int QA_id { get; set; }
        public string Impact { get; set; }
    
        public virtual DecisionRepo DecisionRepo { get; set; }
        public virtual DesignDecision DesignDecision { get; set; }
        public virtual QualityAttribute QualityAttribute { get; set; }
    }
}