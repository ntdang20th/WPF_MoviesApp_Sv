using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tempapp.Model;

namespace tempapp.ViewModel
{
    public class TacGiaViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<TacGia> _ListTacGia;
        public ObservableCollection<TacGia> ListTacGia { get => _ListTacGia; set { _ListTacGia = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        public string _QuocTich;
        public string QuocTich { get => _QuocTich; set { _QuocTich = value; OnPropertyChanged(); } }

        public string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }

        public bool _CheckNam;
        public bool CheckNam{ get => _CheckNam; set { _CheckNam = value; OnPropertyChanged(); } }

        public bool _CheckNu;
        public bool CheckNu { get => _CheckNu; set { _CheckNu = value; OnPropertyChanged(); } }


        public TacGia _SelectedItem;
        public TacGia SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); 
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.TenTacGia;
                    NgaySinh = SelectedItem.NgaySinh;
                    QuocTich = SelectedItem.QuocTich;
                    GioiTinh = SelectedItem.GioiTinh;
                    CheckNam = GioiTinh == "Nam" ? true : false;
                    CheckNu = GioiTinh == "Nữ" ? true : false;
                }
            } 
        }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand Xoa_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public TacGiaViewModel()
        {
            ListTacGia = new ObservableCollection<TacGia>(DataProvider.Instance.DB.TacGias);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(QuocTich) || NgaySinh == null)
                    return false;

                return true;
            }, (p) =>
            {
                GioiTinh = CheckNam ? "Nam" : "Nữ";
                var tg = new TacGia() { TenTacGia = DisplayName, NgaySinh = NgaySinh, GioiTinh = GioiTinh, QuocTich = QuocTich };

                DataProvider.Instance.DB.TacGias.Add(tg);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListTacGia.Add(tg);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(QuocTich) || NgaySinh == null || SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var tgCu = DataProvider.Instance.DB.TacGias.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                tgCu.TenTacGia = DisplayName;
                tgCu.NgaySinh = NgaySinh;
                tgCu.GioiTinh = GioiTinh;
                tgCu.QuocTich = QuocTich;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
                //SelectedItem.TenTacGia = DisplayName;
            });

            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                //xoa khoa phu: Cua_Phim_TacGia
                var tacgiaphim = DataProvider.Instance.DB.Cua_Phim_TacGia.Where(t => t.IdTacGia == SelectedItem.Id).ToList();
                foreach (Cua_Phim_TacGia i in tacgiaphim)
                {
                    DataProvider.Instance.DB.Cua_Phim_TacGia.Remove(i);
                }
                DataProvider.Instance.DB.SaveChanges();

                
                var tgCu = DataProvider.Instance.DB.TacGias.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                DataProvider.Instance.DB.TacGias.Remove(tgCu);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListTacGia.Remove(tgCu);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListTacGia = new ObservableCollection<TacGia>(DataProvider.Instance.DB.TacGias.Where(t => t.TenTacGia.Contains(p.Text)).ToList());
            });
        }

    }
}

