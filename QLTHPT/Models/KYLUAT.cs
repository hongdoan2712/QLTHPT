
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
    
public partial class KYLUAT
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public KYLUAT()
    {

        this.HOCSINHs = new HashSet<HOCSINH>();

    }


    public string KL_MA { get; set; }

    public string KL_HINHTHUC { get; set; }

    public Nullable<System.DateTime> KL_NGAYKYLUAT { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<HOCSINH> HOCSINHs { get; set; }

}

}
