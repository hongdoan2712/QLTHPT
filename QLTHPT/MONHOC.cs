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
    
    public partial class MONHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONHOC()
        {
            this.THOIKHOABIEUs = new HashSet<THOIKHOABIEU>();
            this.SODANHGIAs = new HashSet<SODANHGIA>();
        }
    
        public string MH_MA { get; set; }
        public string MH_TEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THOIKHOABIEU> THOIKHOABIEUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SODANHGIA> SODANHGIAs { get; set; }
    }
}
