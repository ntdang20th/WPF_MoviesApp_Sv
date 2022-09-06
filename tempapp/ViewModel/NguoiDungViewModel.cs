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
    class NguoiDungViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<Quyen> _ListQuyen;
        public ObservableCollection<Quyen> ListQuyen { get => _ListQuyen; set { _ListQuyen = value; OnPropertyChanged(); } }

        public ObservableCollection<NguoiDung> _ListNguoiDung;
        public ObservableCollection<NguoiDung> ListNguoiDung { get => _ListNguoiDung; set { _ListNguoiDung = value; OnPropertyChanged(); } }
        #endregion


        #region Properties
        public NguoiDung _SelectedItem;
        public NguoiDung SelectedItem { get => _SelectedItem; set 
            { 
                _SelectedItem = value; 
                OnPropertyChanged();
                if (SelectedItem == null)
                    return;
                foreach(Quyen q in ListQuyen)
                {
                    q.Check = false;
                }
                foreach (Quyen q in ListQuyen)
                {
                    foreach(Cua_NguoiDung_Quyen i in SelectedItem.Cua_NguoiDung_Quyen)
                    {
                        if (q.Id == i.IdQuyen)
                        {
                            q.Check = true;
                        }
                    }
                }
            } 
        }
        #endregion


        #region Command
        public ICommand Sua_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public NguoiDungViewModel()
        {
            ListQuyen = new ObservableCollection<Quyen>(DataProvider.Instance.DB.Quyens.Where(q=>q.TenQuyen!="Dưới 18 tuổi"));
            ListNguoiDung = new ObservableCollection<NguoiDung>(DataProvider.Instance.DB.NguoiDungs);

          
            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                //xoa khoa phu:  cua
                var quyencuand = DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Where(t => t.IdNguoiDung == SelectedItem.Id).ToList();
                foreach (Cua_NguoiDung_Quyen i in quyencuand)
                {
                    DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Remove(i);
                }
                DataProvider.Instance.DB.SaveChanges();

                //them quyen
                Cua_NguoiDung_Quyen quyenmoi;
                foreach (Quyen t in ListQuyen)
                {
                    if (t.Check == true)
                    {
                        quyenmoi = new Cua_NguoiDung_Quyen()
                        {
                            IdNguoiDung = SelectedItem.Id,
                            IdQuyen = t.Id
                        };
                        DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Add(quyenmoi);
                    }
                }
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã sửa", "Thông báo");
            });


            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListNguoiDung = new ObservableCollection<NguoiDung>(DataProvider.Instance.DB.NguoiDungs.Where(t => t.ThongTin_NguoiDung.Ten.Contains(p.Text)).ToList());
            });
        }

    }
}
