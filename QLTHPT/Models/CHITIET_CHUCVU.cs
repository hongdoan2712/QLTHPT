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
    
    public partial class CHITIET_CHUCVU
    {
        public System.TimeSpan CT_CV_ID { get; set; }
        public string CT_CV_TEN { get; set; }
        public string CANBO_CB_MA { get; set; }
        public string CHUCVU_CV_MA { get; set; }
    
        public virtual CANBO CANBO { get; set; }
        public virtual CHUCVU CHUCVU { get; set; }
    }
}
