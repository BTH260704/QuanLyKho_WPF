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
    
    public partial class OUTPUTINFO
    {
        public string ID { get; set; }
        public string IDOBJECT { get; set; }
        public int IDCUSTOMER { get; set; }
        public string IDOUTPUT { get; set; }
        public Nullable<int> COUNT { get; set; }
        public string STATUS { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual OBJECTSS OBJECTSS { get; set; }
        public virtual OUTPUT OUTPUT { get; set; }
    }
}
