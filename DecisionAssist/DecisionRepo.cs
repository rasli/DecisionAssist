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
    
    public partial class DecisionRepo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DecisionRepo()
        {
            this.DecisionQAimpacts = new HashSet<DecisionQAimpact>();
        }
    
        public int DR_id { get; set; }
        public string DR_name { get; set; }
        public string DR_des { get; set; }
        public string DR_type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DecisionQAimpact> DecisionQAimpacts { get; set; }
    }
}
