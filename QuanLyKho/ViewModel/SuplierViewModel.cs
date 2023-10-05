using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class SuplierViewModel: BaseViewModel
    {
        private ObservableCollection<SUPLIER> _List;
        public ObservableCollection<SUPLIER> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private SUPLIER _SelectedItem;
        public SUPLIER SelectedItem 
        { 
            get => _SelectedItem; 
            set 
            { 
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DISPLAYNAME;
                    Email = SelectedItem.EMAIL;
                    Phone = SelectedItem.PHONE;
                    Address = SelectedItem.ADDRESS;
                    MoreInfo = SelectedItem.MOREINFO;
                    ContractDate = SelectedItem.CONTRACTDATE;
                }
            } 
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public SuplierViewModel()
        {
            List = new ObservableCollection<SUPLIER>(DataProvider.Ins.DB.SUPLIERs.ToList());

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var SUPLIER = new SUPLIER() { DISPLAYNAME = DisplayName,PHONE = Phone, ADDRESS =Address, EMAIL = Email,MOREINFO =MoreInfo,CONTRACTDATE = ContractDate };
                DataProvider.Ins.DB.SUPLIERs.Add(SUPLIER);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(SUPLIER);
            });


            EditCommand = new RelayCommand<object>((p) =>
            {
                if ( SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.SUPLIERs.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var SUPLIER = DataProvider.Ins.DB.SUPLIERs.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();
                SUPLIER.DISPLAYNAME = DisplayName;
                SUPLIER.PHONE = Phone;
                SUPLIER.ADDRESS = Address;
                SUPLIER.EMAIL = Email;
                SUPLIER.MOREINFO = MoreInfo; 
                SUPLIER.CONTRACTDATE = ContractDate;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DISPLAYNAME = DisplayName;
            });
        }
    }
}
