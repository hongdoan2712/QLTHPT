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
    
    public partial class NGACHLUONG
    {
        public NGACHLUONG()
        {
            this.THONGTINLUONGs = new HashSet<THONGTINLUONG>();
        }
    
        public string NL_MA { get; set; }
        public string NL_TEN { get; set; }
    
        public virtual ICollection<THONGTINLUONG> THONGTINLUONGs { get; set; }
    }
}
