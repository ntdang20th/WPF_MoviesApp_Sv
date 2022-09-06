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
    class LuatViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<Luat> _ListLuat;
        public ObservableCollection<Luat> ListLuat { get => _ListLuat; set { _ListLuat = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public Luat _SelectedItem;
        public Luat SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null) DisplayName = SelectedItem.TenLuat; } }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand Xoa_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public LuatViewModel()
        {
            ListLuat = new ObservableCollection<Luat>(DataProvider.Instance.DB.Luats);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName))
                    return false;

                var ds = DataProvider.Instance.DB.Luats.Where(t => t.TenLuat == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var cd = new Luat() { TenLuat = DisplayName };

                DataProvider.Instance.DB.Luats.Add(cd);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListLuat.Add(cd);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var ds = DataProvider.Instance.DB.Luats.Where(t => t.TenLuat == DisplayName);

                if (ds == null || ds.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var luatCU = DataProvider.Instance.DB.Luats.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                luatCU.TenLuat = DisplayName;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
                SelectedItem.TenLuat = DisplayName;
            });

            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var luatCu = DataProvider.Instance.DB.Luats.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                DataProvider.Instance.DB.Luats.Remove(luatCu);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListLuat.Remove(luatCu);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListLuat = new ObservableCollection<Luat>(DataProvider.Instance.DB.Luats.Where(t => t.TenLuat.Contains(p.Text)).ToList());
            });
        }

    }
}
