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
    public class ChuDeViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<ChuDe> _ListChuDe;
        public ObservableCollection<ChuDe> ListChuDe { get => _ListChuDe; set { _ListChuDe = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public ChuDe _SelectedItem;
        public ChuDe SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null) DisplayName = SelectedItem.TenChuDe; } }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand Xoa_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public ChuDeViewModel()
        {
            ListChuDe = new ObservableCollection<ChuDe>(DataProvider.Instance.DB.ChuDes);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName))
                    return false;

                var ds = DataProvider.Instance.DB.ChuDes.Where(t => t.TenChuDe == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var cd = new ChuDe() { TenChuDe = DisplayName };

                DataProvider.Instance.DB.ChuDes.Add(cd);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListChuDe.Add(cd);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var ds = DataProvider.Instance.DB.ChuDes.Where(t => t.TenChuDe == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var cdCu = DataProvider.Instance.DB.ChuDes.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                cdCu.TenChuDe = DisplayName;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
                SelectedItem.TenChuDe = DisplayName;
            });


            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var cdCu = DataProvider.Instance.DB.ChuDes.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                DataProvider.Instance.DB.ChuDes.Remove(cdCu);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListChuDe.Remove(cdCu);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListChuDe = new ObservableCollection<ChuDe>(DataProvider.Instance.DB.ChuDes.Where(t => t.TenChuDe.Contains(p.Text)).ToList());
            });
        }

    }
}
