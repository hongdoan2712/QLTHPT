
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
    
public partial class COSOVATCHAT
{

    public string CSVC_MA { get; set; }

    public int CSVC_SOLUONG { get; set; }



    public virtual PHONGHOC PHONGHOC { get; set; }

    public virtual THIETBIGIANGDAY THIETBIGIANGDAY { get; set; }

    public virtual THIETBIDAYHOC THIETBIDAYHOC { get; set; }

    public virtual TINHTRANG TINHTRANG { get; set; }

}

}
