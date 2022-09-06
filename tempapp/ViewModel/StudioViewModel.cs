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
    class StudioViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<Studio> _ListStudio;
        public ObservableCollection<Studio> ListStudio { get => _ListStudio; set { _ListStudio = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public string _GhiChu;
        public string GhiChu { get => _GhiChu; set { _GhiChu = value; OnPropertyChanged(); } }

        public Studio _SelectedItem;
        public Studio SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.TenStudio;
                    GhiChu = SelectedItem.GhiChu;
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

        public StudioViewModel()
        {
            ListStudio = new ObservableCollection<Studio>(DataProvider.Instance.DB.Studios);

            Them_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(GhiChu))
                    return false;

                return true;
            }, (p) =>
            {
                var std = new Studio() { TenStudio = DisplayName, GhiChu = GhiChu };

                DataProvider.Instance.DB.Studios.Add(std);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã thêm", "Thông báo");
                ListStudio.Add(std);
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(GhiChu) || SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var stdCu = DataProvider.Instance.DB.Studios.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                stdCu.TenStudio = DisplayName;
                stdCu.GhiChu = GhiChu;
                MessageBox.Show("Đã sửa", "Thông báo");
                DataProvider.Instance.DB.SaveChanges();
            });

            Xoa_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                //xoa khoa phu: Cua_Phim_Studio
                var studiophim = DataProvider.Instance.DB.Cua_Phim_Studio.Where(t => t.IdStudio== SelectedItem.Id).ToList();
                foreach (Cua_Phim_Studio i in studiophim)
                {
                    DataProvider.Instance.DB.Cua_Phim_Studio.Remove(i);
                }
                DataProvider.Instance.DB.SaveChanges();


                var stdCu = DataProvider.Instance.DB.Studios.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                DataProvider.Instance.DB.Studios.Remove(stdCu);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã xóa", "Thông báo");
                ListStudio.Remove(stdCu);
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListStudio = new ObservableCollection<Studio>(DataProvider.Instance.DB.Studios.Where(t => t.TenStudio.Contains(p.Text)).ToList());
            });
        }

    }
}

