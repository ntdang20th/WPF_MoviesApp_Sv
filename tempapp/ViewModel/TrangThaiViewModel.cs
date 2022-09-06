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
    public class TrangThaiViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<TrangThai> _ListTrangThai;
        public ObservableCollection<TrangThai> ListTrangThai { get => _ListTrangThai; set { _ListTrangThai = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public TrangThai _SelectedItem;
        public TrangThai SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null) DisplayName = SelectedItem.TenTrangThai; } }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand Xoa_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public TrangThaiViewModel()
        {
            ListTrangThai = new ObservableCollection<TrangThai>(DataProvider.Instance.DB.TrangThais);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName))
                    return false;

                var ds = DataProvider.Instance.DB.TrangThais.Where(t => t.TenTrangThai == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var tt = new TrangThai() { TenTrangThai = DisplayName };

                DataProvider.Instance.DB.TrangThais.Add(tt);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListTrangThai.Add(tt);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var ds = DataProvider.Instance.DB.TrangThais.Where(t => t.TenTrangThai == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var ttCu = DataProvider.Instance.DB.TrangThais.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                ttCu.TenTrangThai = DisplayName;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
                SelectedItem.TenTrangThai = DisplayName;
            });

            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var ttCu = DataProvider.Instance.DB.TrangThais.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                DataProvider.Instance.DB.TrangThais.Remove(ttCu);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListTrangThai.Remove(ttCu);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListTrangThai = new ObservableCollection<TrangThai>(DataProvider.Instance.DB.TrangThais.Where(t => t.TenTrangThai.Contains(p.Text)).ToList());
            });
        }

    }
}

