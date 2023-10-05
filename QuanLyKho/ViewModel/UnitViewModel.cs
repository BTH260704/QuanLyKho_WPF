using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class UnitViewModel: BaseViewModel
    {
        private ObservableCollection<UNIT> _List;
        public ObservableCollection<UNIT> List { get => _List; set { _List = value;OnPropertyChanged(); } }

        private UNIT _SelectedItem;
        public UNIT SelectedItem { get => _SelectedItem; set {_SelectedItem = value;OnPropertyChanged();if (SelectedItem != null) { DisplayName = SelectedItem.DISPLAYNAME; } } }

        private string  _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public UnitViewModel()
        {
            List = new ObservableCollection<UNIT>(DataProvider.Ins.DB.UNITs.ToList());

            AddCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;
                var displayList = DataProvider.Ins.DB.UNITs.Where(x => x.DISPLAYNAME == DisplayName);
                if(displayList == null|| displayList.Count() != 0)
                    return false;
                return true;
            }, (p) => 
            {
                var unit = new UNIT() { DISPLAYNAME = DisplayName };
                DataProvider.Ins.DB.UNITs.Add(unit);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(unit);
            });


            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.UNITs.Where(x => x.DISPLAYNAME == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var unit = DataProvider.Ins.DB.UNITs.Where(x=>x.ID ==  SelectedItem.ID).SingleOrDefault();
                unit.DISPLAYNAME = DisplayName;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DISPLAYNAME = DisplayName;
            });
        }
    }
}
