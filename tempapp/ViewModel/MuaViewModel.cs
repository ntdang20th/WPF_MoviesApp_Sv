using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tempapp.Model;

namespace tempapp.ViewModel
{
    class MuaViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<Mua> _ListMua;
        public ObservableCollection<Mua> ListMua { get => _ListMua; set { _ListMua = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public Mua _SelectedItem;
        public Mua SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null) DisplayName = SelectedItem.TenMua; } }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand Xoa_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public MuaViewModel()
        {
            ListMua = new ObservableCollection<Mua>(DataProvider.Instance.DB.Muas);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName))
                    return false;

                var ds = DataProvider.Instance.DB.Muas.Where(t => t.TenMua == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var cd = new Mua() { TenMua = DisplayName };

                DataProvider.Instance.DB.Muas.Add(cd);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListMua.Add(cd);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var ds = DataProvider.Instance.DB.Muas.Where(t => t.TenMua == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var muaCU = DataProvider.Instance.DB.Muas.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                muaCU.TenMua = DisplayName;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
                SelectedItem.TenMua = DisplayName;
            });

            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var muaCU = DataProvider.Instance.DB.Muas.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                DataProvider.Instance.DB.Muas.Remove(muaCU);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListMua.Remove(muaCU);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListMua = new ObservableCollection<Mua>(DataProvider.Instance.DB.Muas.Where(t => t.TenMua.Contains(p.Text)).ToList());
            });
        }

    }
}
