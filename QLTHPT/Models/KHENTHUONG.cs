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
    
    public partial class KHENTHUONG
    {
        public string KT_MA { get; set; }
        public string KT_THANHTICH { get; set; }
        public Nullable<System.DateTime> KT_NGAYKHENTHUONG { get; set; }
        public string KT_GHICHU { get; set; }
    
        public virtual HOCSINH HOCSINH { get; set; }
    }
}
