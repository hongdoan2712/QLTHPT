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
    
    public partial class TIETHOC
    {
        public string TH_MA { get; set; }
        public string TH_TEN { get; set; }
        public string THOIKHOABIEU_TKB_MA { get; set; }
    
        public virtual THOIKHOABIEU THOIKHOABIEU { get; set; }
    }
}
