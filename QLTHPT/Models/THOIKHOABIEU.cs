//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTHPT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THOIKHOABIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THOIKHOABIEU()
        {
            this.MONHOCs = new HashSet<MONHOC>();
            this.THUs = new HashSet<THU>();
            this.TIETHOCs = new HashSet<TIETHOC>();
        }
    
        public string TKB_MA { get; set; }
        public string LOP_LOP_MA { get; set; }
    
        public virtual LOP LOP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MONHOC> MONHOCs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THU> THUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIETHOC> TIETHOCs { get; set; }
    }
}
