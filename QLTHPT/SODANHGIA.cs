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
    
    public partial class SODANHGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SODANHGIA()
        {
            this.CHITIETDANHGIAs = new HashSet<CHITIETDANHGIA>();
            this.HOCSINHs = new HashSet<HOCSINH>();
        }
    
        public string SDG_MA { get; set; }
        public string SDG_DIEM { get; set; }
        public string SDG_GHICHU { get; set; }
        public string MH_MA { get; set; }
        public string HOCKYHK_MA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDANHGIA> CHITIETDANHGIAs { get; set; }
        public virtual HOCKy HOCKy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }
        public virtual MONHOC MONHOC { get; set; }
    }
}
