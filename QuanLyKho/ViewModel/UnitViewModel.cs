using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.ViewModel
{
    public class UnitViewModel: BaseViewModel
    {
        private ObservableCollection<UNIT> _List;
        public ObservableCollection<UNIT> List { get => _List; set { _List = value;OnPropertyChanged(); } }

        private ObservableCollection<UNIT> _SelectedItem;
        public ObservableCollection<UNIT> SelectedItem 
        { 
            get => _SelectedItem; 
            set 
            { 
                _SelectedItem = value; OnPropertyChanged();
     
            } 
        }

        private ObservableCollection<UNIT> _DisplayName;
        public ObservableCollection<UNIT> DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        public UnitViewModel()
        {
            List = new ObservableCollection<UNIT>(DataProvider.Ins.DB.UNITs.ToList());
        }
    }
}
