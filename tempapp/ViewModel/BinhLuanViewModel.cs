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
    class BinhLuanViewModel : BaseViewModel
    {
        #region List
        public ObservableCollection<Phim> _ListPhim;
        public ObservableCollection<Phim> ListPhim { get => _ListPhim; set { _ListPhim = value; OnPropertyChanged(); } }

        public ObservableCollection<NguoiDung_BinhLuan_Phim> _ListBinhLuan;
        public ObservableCollection<NguoiDung_BinhLuan_Phim> ListBinhLuan { get => _ListBinhLuan; set { _ListBinhLuan = value; OnPropertyChanged(); } }
        #endregion


        #region Properties

        public Phim _SelectedItem;
        public Phim SelectedItem { get => _SelectedItem; set 
            { 
                _SelectedItem = value; 
                OnPropertyChanged();
                if (SelectedItem != null)
                    ListBinhLuan = new ObservableCollection<NguoiDung_BinhLuan_Phim>(SelectedItem.NguoiDung_BinhLuan_Phim);
            } 
        }

        public NguoiDung_BinhLuan_Phim _SelectedBinhLuan;
        public NguoiDung_BinhLuan_Phim SelectedBinhLuan { get => _SelectedBinhLuan; set { _SelectedBinhLuan = value; OnPropertyChanged(); } }
        #endregion


        #region Command
        public ICommand XoaBinhLuanCommand { get; set; }
        public ICommand CamBinhLuanCommand { get; set; }
        public ICommand CamXemCommand { get; set; }
        public ICommand BANCommand { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public BinhLuanViewModel()
        {
            ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.DB.Phims);

            XoaBinhLuanCommand = new RelayCommand<TextBox>((p) =>
            {
                if (SelectedBinhLuan == null)
                    return false;
                return true;
            }, (p) =>
            {
                var binhluan = DataProvider.Instance.DB.NguoiDung_BinhLuan_Phim.Where(t => t.Id == SelectedBinhLuan.Id).SingleOrDefault();
                DataProvider.Instance.DB.NguoiDung_BinhLuan_Phim.Remove(binhluan);
                DataProvider.Instance.DB.SaveChanges();

                ListBinhLuan.Remove(binhluan);
                MessageBox.Show("Đã xóa bình luận", "Thông báo");

            });

            CamBinhLuanCommand = new RelayCommand<TextBox>((p) =>
            {
                if (SelectedBinhLuan == null)
                    return false;
                return true;
            }, (p) =>
            {
                var listquyen = DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Where(t => t.IdNguoiDung == SelectedBinhLuan.IdNguoiDung);
                
                foreach(Cua_NguoiDung_Quyen q in listquyen.ToList())
                {
                    //nếu tài khoản đã bị khóa mỗm rồi
                    if(q.Quyen.TenQuyen == "Cấm bình luận")
                    {
                        MessageBox.Show("Đã Cấm bình luận tài khoản " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ho_HoLot + " " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ten, "Thông báo");
                        return;
                    }
                }

                //neu chua bij khoa mom~ -> them cai ro mom vao
                Cua_NguoiDung_Quyen quyen = new Cua_NguoiDung_Quyen() { IdNguoiDung = SelectedBinhLuan.IdNguoiDung, IdQuyen = DataProvider.Instance.DB.Quyens.Where(t => t.TenQuyen == "Cấm bình luận").Select(x => x.Id).SingleOrDefault() };
                DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Add(quyen);
                
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã Cấm bình luận tài khoản " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ho_HoLot + " " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ten, "Thông báo");

            });

            CamXemCommand = new RelayCommand<TextBox>((p) =>
            {
                if (SelectedBinhLuan == null)
                    return false;
                return true;
            }, (p) =>
            {
                var listquyen = DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Where(t => t.IdNguoiDung == SelectedBinhLuan.IdNguoiDung);

                foreach (Cua_NguoiDung_Quyen q in listquyen.ToList())
                {
                    //nếu tài khoản đã bị khóa mỗm rồi
                    if (q.Quyen.TenQuyen == "Cấm xem")
                    {
                        MessageBox.Show("Đã Cấm xem tài khoản " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ho_HoLot + " " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ten, "Thông báo");
                        return;
                    }
                }

                //neu chuacam xem -> ban
                Cua_NguoiDung_Quyen quyen = new Cua_NguoiDung_Quyen() { IdNguoiDung = SelectedBinhLuan.IdNguoiDung, IdQuyen = DataProvider.Instance.DB.Quyens.Where(t => t.TenQuyen == "Cấm xem").Select(x => x.Id).SingleOrDefault() };
                DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Add(quyen);

                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đã Cấm xem tài khoản " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ho_HoLot + " " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ten, "Thông báo");
            });

            BANCommand = new RelayCommand<TextBox>((p) =>
            {
                if (SelectedBinhLuan == null)
                    return false;
                return true;
            }, (p) =>
            {
                var listquyen = DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Where(t => t.IdNguoiDung == SelectedBinhLuan.IdNguoiDung);

                foreach (Cua_NguoiDung_Quyen q in listquyen.ToList())
                {
                    //nếu tài khoản đã bị khóa mỗm rồi
                    if (q.Quyen.TenQuyen == "Cấm xem")
                    {
                        MessageBox.Show("Đã BAN tài khoản " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ho_HoLot + " " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ten, "Thông báo");
                        return;
                    }
                }

                //neu chuacam xem -> ban
                Cua_NguoiDung_Quyen quyen = new Cua_NguoiDung_Quyen() { IdNguoiDung = SelectedBinhLuan.IdNguoiDung, IdQuyen = DataProvider.Instance.DB.Quyens.Where(t => t.TenQuyen == "BAN").Select(x => x.Id).SingleOrDefault() };
                DataProvider.Instance.DB.Cua_NguoiDung_Quyen.Add(quyen);

                DataProvider.Instance.DB.SaveChanges();

                MessageBox.Show("Đã BAN tài khoản " + SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ho_HoLot +" "+ SelectedBinhLuan.NguoiDung.ThongTin_NguoiDung.Ten, "Thông báo");
            });



            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.DB.Phims.Where(t => t.TenPhim.Contains(p.Text)).ToList());
            });
        }

    }
}
