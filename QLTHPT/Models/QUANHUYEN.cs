//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTHPT.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class QUANHUYEN
    {
        public QUANHUYEN()
        {
            this.HOCSINHs = new HashSet<HOCSINH>();
        }
    
        public string QH_MA { get; set; }
        public string QH_TEN { get; set; }
    
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }
    }
}
