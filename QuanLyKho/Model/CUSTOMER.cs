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
    
    public partial class CUSTOMER: BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.OUTPUTINFOes = new HashSet<OUTPUTINFO>();
        }
    
        public int ID { get; set; }
        private string _DISPLAYNAME;
        public string DISPLAYNAME { get => _DISPLAYNAME; set { _DISPLAYNAME = value; OnPropertyChanged(); } }

        private string _ADDRESS;
        public string ADDRESS { get => _ADDRESS; set { _ADDRESS = value; OnPropertyChanged(); } }

        private string _PHONE;
        public string PHONE { get => _PHONE; set { _PHONE = value; OnPropertyChanged(); } }

        private string _EMAIL;
        public string EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }
        private string _MOREINFO;
        public string MOREINFO { get => _MOREINFO; set { _MOREINFO = value; OnPropertyChanged(); } }

        private Nullable<System.DateTime> _CONTRACTDATE { get; set; }

        public Nullable<System.DateTime> CONTRACTDATE { get => _CONTRACTDATE; set { _CONTRACTDATE = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTPUTINFO> OUTPUTINFOes { get; set; }
    }
}
