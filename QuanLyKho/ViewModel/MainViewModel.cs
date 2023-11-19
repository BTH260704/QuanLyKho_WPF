using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }   
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }

        // Để theo dõi trạng thái hiển thị của LoginWindow
        private bool loginWindowShown = false;

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    IsLoaded = true;
                    if (p == null)
                        return;
                    p.Hide();
                    LoginWindow login = new LoginWindow();
                    login.ShowDialog();

                    if (login.DataContext == null)
                        return;
                    var loginVM = login.DataContext as LoginViewModel; 

                    if(loginVM.IsLogin) 
                    {
                        p.Show();
                        LoadTonKhoData();                    }
                    else
                    {
                        p.Close();
                    }
                });
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>{UnitWindow wd = new UnitWindow();wd.ShowDialog();});
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>{ SuplierWindow wd = new SuplierWindow();wd.ShowDialog();});
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>{ CustomerWindow wd = new CustomerWindow();wd.ShowDialog();});
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindow wd = new ObjectWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wd = new UserWindow(); wd.ShowDialog(); });
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindow wd = new InputWindow(); wd.ShowDialog(); });
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindow wd = new OutputWindow(); wd.ShowDialog(); });

        }
        void LoadTonKhoData()
        {
            TonKhoList = new ObservableCollection<TonKho>();
            var objectList = DataProvider.Ins.DB.OBJECTSSes;

            int i = 1;
            foreach (var item in objectList)
            {
                var inputList  = DataProvider.Ins.DB.INPUTINFOes.Where(p=>p.IDOBJECT == item.ID);
                var outputList  = DataProvider.Ins.DB.OUTPUTINFOes.Where(p=>p.IDOBJECT == item.ID);
                int SumInput = 0;
                int SumOutput = 0;
                if (inputList != null)
                    SumInput = (int)inputList.Sum(p => p.COUNT);
                if (outputList != null)
                    SumOutput = (int)outputList.Sum(p => p.COUNT);
                TonKho tonkho = new TonKho();
                tonkho.STT = i;
                tonkho.Count = SumInput - SumOutput;
                tonkho.Object = item;
                TonKhoList.Add(tonkho);
                i++;
            }
        }
    }

}
