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
    
    public partial class VANBANG
    {
        public VANBANG()
        {
            this.THONGTINDAOTAOs = new HashSet<THONGTINDAOTAO>();
        }
    
        public string VB_MA { get; set; }
        public string VB_TEN { get; set; }
    
        public virtual ICollection<THONGTINDAOTAO> THONGTINDAOTAOs { get; set; }
    }
}
