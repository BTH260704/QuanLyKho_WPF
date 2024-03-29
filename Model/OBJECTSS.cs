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
    using QuanLyKho.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class OBJECTSS: BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBJECTSS()
        {
            this.INPUTINFOes = new HashSet<INPUTINFO>();
            this.OUTPUTINFOes = new HashSet<OUTPUTINFO>();
        }
        private string _ID;
        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }

        private string _DISPLAYNAME;
        public string DISPLAYNAME { get => _DISPLAYNAME; set { _DISPLAYNAME = value; OnPropertyChanged(); } }

        private int _IDUNIT;
        public int IDUNIT { get => _IDUNIT; set { _IDUNIT = value; OnPropertyChanged(); } }

        private int _IDSUPLIER;
        public int IDSUPLIER { get => _IDSUPLIER; set { _IDSUPLIER = value; OnPropertyChanged(); } }

        private string _QRCODE;
        public string QRCODE { get => _QRCODE; set { _QRCODE = value; OnPropertyChanged(); } }

        private string _BARCODE;
        public string BARCODE { get => _BARCODE; set { _BARCODE = value; OnPropertyChanged(); } }

    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INPUTINFO> INPUTINFOes { get; set; }
       
        private  SUPLIER _SUPLIER;
        public virtual SUPLIER SUPLIER { get => _SUPLIER; set { _SUPLIER = value; OnPropertyChanged(); } }
        private UNIT _UNIT;
        public virtual UNIT UNIT { get => _UNIT; set { _UNIT = value; OnPropertyChanged(); } }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTPUTINFO> OUTPUTINFOes { get; set; }
    }
}
