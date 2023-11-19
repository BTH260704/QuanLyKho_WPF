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
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Model.OBJECTSS> _List;
        public ObservableCollection<Model.OBJECTSS> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.UNIT> _Unit;
        public ObservableCollection<Model.UNIT> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.SUPLIER> _Suplier;
        public ObservableCollection<Model.SUPLIER> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        private Model.OBJECTSS _SelectedItem;
        public Model.OBJECTSS SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DISPLAYNAME;
                    QRCode = SelectedItem.QRCODE;
                    BarCode = SelectedItem.BARCODE;
                    SelectedUnit = SelectedItem.UNIT;
                    SelectedSuplier = SelectedItem.SUPLIER;
                }
            }
        }

        private Model.UNIT _SelectedUnit;
        public Model.UNIT SelectedUnit
        {
            get => _SelectedUnit;
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
            }
        }

        private Model.SUPLIER _SelectedSuplier;
        public Model.SUPLIER SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }


        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }


        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }


        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ObjectViewModel()
        {
            List = new ObservableCollection<Model.OBJECTSS >(DataProvider.Ins.DB.OBJECTSSes);
            Unit = new ObservableCollection<Model.UNIT>(DataProvider.Ins.DB.UNITs);
            Suplier = new ObservableCollection<Model.SUPLIER>(DataProvider.Ins.DB.SUPLIERs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null || SelectedUnit == null)
                    return false;
                return true;

            }, (p) =>
            {
                var Object = new Model.OBJECTSS() { DISPLAYNAME = DisplayName, BARCODE = BarCode, QRCODE = QRCode, IDSUPLIER = SelectedSuplier.ID, IDUNIT = SelectedUnit.ID, ID = Guid.NewGuid().ToString() };

                DataProvider.Ins.DB.OBJECTSSes.Add(Object);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Object);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedSuplier == null || SelectedUnit == null)
                    return false;

                var displayList = DataProvider.Ins.DB.OBJECTSSes.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.OBJECTSSes.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();
                Object.DISPLAYNAME = DisplayName;
                Object.BARCODE = BarCode;
                Object.QRCODE = QRCode;
                Object.IDSUPLIER = SelectedSuplier.ID;
                Object.IDUNIT = SelectedUnit.ID;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.DISPLAYNAME = DisplayName;
            });
        }
    }
}
