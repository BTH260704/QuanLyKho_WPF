//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKho.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OBJECTSS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBJECTSS()
        {
            this.INPUTINFOes = new HashSet<INPUTINFO>();
            this.OUTPUTINFOes = new HashSet<OUTPUTINFO>();
        }
    
        public string ID { get; set; }
        public string DISPLAYNAME { get; set; }
        public int IDUNIT { get; set; }
        public int IDSUPLIER { get; set; }
        public string QRCODE { get; set; }
        public string BARCODE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INPUTINFO> INPUTINFOes { get; set; }
        public virtual SUPLIER SUPLIER { get; set; }
        public virtual UNIT UNIT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTPUTINFO> OUTPUTINFOes { get; set; }
    }
}
