using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tempapp.Model;

namespace tempapp.ViewModel
{
    public class TheLoaiViewModel:BaseViewModel
    {
        #region List
        public ObservableCollection<TheLoai> _ListTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => _ListTheLoai; set { _ListTheLoai = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public TheLoai _SelectedItem;
        public TheLoai SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null) DisplayName = SelectedItem.TenTheLoai; } }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand Xoa_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public TheLoaiViewModel()
        {
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.DB.TheLoais);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName))
                    return false;

                var ds = DataProvider.Instance.DB.TheLoais.Where(t => t.TenTheLoai == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p)=> 
            {
                var tl = new TheLoai() { TenTheLoai = DisplayName };

                DataProvider.Instance.DB.TheLoais.Add(tl);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListTheLoai.Add(tl);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var ds = DataProvider.Instance.DB.TheLoais.Where(t => t.TenTheLoai == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var tlCu = DataProvider.Instance.DB.TheLoais.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                tlCu.TenTheLoai = DisplayName;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
                SelectedItem.TenTheLoai = DisplayName;
            });

            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                //xoa khoa phu: Cua_Phim_TheLoai
                var theloaiphim = DataProvider.Instance.DB.Cua_Phim_TheLoai.Where(t => t.IdTheLoai == SelectedItem.Id).ToList();
                foreach(Cua_Phim_TheLoai i in theloaiphim)
                {
                    DataProvider.Instance.DB.Cua_Phim_TheLoai.Remove(i);
                }
                DataProvider.Instance.DB.SaveChanges();

                //xoa khoa chinh
                var tlCu = DataProvider.Instance.DB.TheLoais.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();

                DataProvider.Instance.DB.TheLoais.Remove(tlCu);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListTheLoai.Remove(tlCu);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.DB.TheLoais.Where(t => t.TenTheLoai.Contains(p.Text)).ToList());
            });
        }

    }
}
