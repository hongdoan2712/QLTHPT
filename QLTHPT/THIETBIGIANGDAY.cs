//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTHPT
{
    using System;
    using System.Collections.Generic;
    
    public partial class THIETBIGIANGDAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THIETBIGIANGDAY()
        {
            this.COSOVATCHATs = new HashSet<COSOVATCHAT>();
        }
    
        public string TBGD_MA { get; set; }
        public string TBGD_TEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COSOVATCHAT> COSOVATCHATs { get; set; }
    }
}
