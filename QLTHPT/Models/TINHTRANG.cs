
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
    
public partial class TINHTRANG
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TINHTRANG()
    {

        this.COSOVATCHATs = new HashSet<COSOVATCHAT>();

    }


    public string TT_MA { get; set; }

    public string TT_MOTA { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<COSOVATCHAT> COSOVATCHATs { get; set; }

}

}
