using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace tempapp.ViewModel
{
    class MainViewModel: BaseViewModel
    {
        bool IsLoaded = false;

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand TheLoaiViewCommand { get; set; }
        public ICommand ChuDeViewCommand { get; set; }
        public ICommand TrangThaiCommand { get; set; }
        public ICommand TacGiaCommand { get; set; }
        public ICommand StudioCommand { get; set; }
        public ICommand PhimCommand { get; set; }
        public ICommand MuaCommand { get; set; }
        public ICommand LuatCommand { get; set; }
        public ICommand NguoiDungCommand { get; set; }
        public ICommand BinhLuanCommand { get; set; }
        public ICommand ThongKeCommand { get; set; }

        public TheLoaiViewModel TheLoaiVM { get; set; }
        public ChuDeViewModel ChuDeVM { get; set; }
        public TrangThaiViewModel TrangThaiVM { get; set; }
        public TacGiaViewModel TacGiaVM { get; set; }
        public StudioViewModel StudioVM { get; set; }
        public PhimViewModel PhimVM { get; set; }
        public MuaViewModel MuaVM { get; set; }
        public LuatViewModel LuatVM { get; set; }
        public NguoiDungViewModel NguoiDungVM { get; set; }
        public BinhLuanViewModel BinhLuanVM { get; set; }
        public ThongKeViewModel ThongKeVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                IsLoaded = true;

                p.Hide();
                LoginWindow l = new LoginWindow();
                l.ShowDialog();

                var loginVM = l.DataContext as LoginViewModel;
                if (loginVM == null)
                    return;

                if (loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });

            

            TheLoaiVM = new TheLoaiViewModel();
            ChuDeVM = new ChuDeViewModel();
            TrangThaiVM = new TrangThaiViewModel();
            TacGiaVM = new TacGiaViewModel();
            StudioVM = new StudioViewModel();
            PhimVM = new PhimViewModel();
            MuaVM = new MuaViewModel();
            LuatVM = new LuatViewModel();
            NguoiDungVM = new NguoiDungViewModel();
            BinhLuanVM = new BinhLuanViewModel();
            ThongKeVM = new ThongKeViewModel();


            TheLoaiViewCommand = new RelayCommand<object>((p) => { return true; }, (p)=>{
                CurrentView = TheLoaiVM;
            });

            ChuDeViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = ChuDeVM;
            });

            TrangThaiCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = TrangThaiVM;
            });

            TacGiaCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = TacGiaVM;
            });

            StudioCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = StudioVM;
            });

            PhimCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = PhimVM;
            });
            MuaCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = MuaVM;
            });
            LuatCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = LuatVM;
            });
            NguoiDungCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = NguoiDungVM;
            }); 
            BinhLuanCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = BinhLuanVM;
            });
            ThongKeCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                CurrentView = ThongKeVM;
            });
        }
    }
}
