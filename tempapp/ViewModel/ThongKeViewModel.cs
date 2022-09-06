using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using tempapp.Model;

namespace tempapp.ViewModel
{
    class ThongKeViewModel:BaseViewModel
    {
        string duongdangoc = "D:\\data\\";
        private Phim _P_XemNhieu;
        public Phim P_XemNhieu { get => _P_XemNhieu; set { _P_XemNhieu = value; OnPropertyChanged(); } }

        private Phim _P_BinhLuanNhieu;
        public Phim P_BinhLuanNhieu { get => _P_BinhLuanNhieu; set { _P_BinhLuanNhieu = value; OnPropertyChanged(); } }

        private Phim _P_DandGiaCao;
        public Phim P_DandGiaCao { get => _P_DandGiaCao; set { _P_DandGiaCao = value; OnPropertyChanged(); } }


        private DateTime _NgayBatDau;
        public DateTime NgayBatDau { get => _NgayBatDau; set { _NgayBatDau = value; OnPropertyChanged(); } }
        private DateTime _NgayKetThuc;
        public DateTime NgayKetThuc { get => _NgayKetThuc; set { _NgayKetThuc = value; OnPropertyChanged(); } }


        private SeriesCollection _Collection;
        public SeriesCollection Collection { get => _Collection; set { _Collection = value; OnPropertyChanged(); } }

        private Axis _Thang;
        public Axis Thang { get => _Thang; set { _Thang = value; OnPropertyChanged(); } }

        private Axis _LuotXem;
        public Axis LuotXem { get => _LuotXem; set { _LuotXem = value; OnPropertyChanged(); } }

        public ICommand ThongKeCommand { get; set; }


        public ThongKeViewModel()
        {
            NgayKetThuc = DateTime.Today;
            NgayBatDau = DateTime.Parse((NgayKetThuc.Month)+ "/1/"  + NgayKetThuc.Year);


            //tinh luot xem trong 3 thang gan nhat
            List<int> values = new List<int>();
            SeriesCollection series = new SeriesCollection();

            //lay danh sach: thang, luot xem
            DateTime ngaydaunam = DateTime.Parse("1/1/" + DateTime.Today.Year);
            var temp = DataProvider.Instance.DB.NguoiDung_Xem_Phim.Where(x => x.NgayXem  >= ngaydaunam)
                                                      .GroupBy(x => x.NgayXem)
                                                      .Select(x => new { Name = x.Key, Total = x.Count() })
                                                      .OrderByDescending(x => x.Total)
                                                      .ToList();

            int Thang = 1;
            int value = 0;
            for (int month = 1; month <= 12; month++)
            {
                foreach (var i in temp)
                {
                    DateTime date = (DateTime)i.Name;
                    if (date.Month == Thang)
                    {
                        value += i.Total;
                    }
                }
                Thang++;
                values.Add(value);
                value = 0;
            }

            series.Add(new LineSeries() { Title = DateTime.Today.Year.ToString(), Values = new ChartValues<int>(values) });
            Collection = series;


            ThongKeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                P_XemNhieu = GetMostView(NgayBatDau, NgayKetThuc.AddDays(1));
                P_BinhLuanNhieu = GetMostComment(NgayBatDau, NgayKetThuc.AddDays(1));
                P_DandGiaCao = GetMostRate();


                createChart();
            });
        }

        void createChart()
        {
            Thang = new Axis
            {
                Title = "Tháng",
                Labels = new[] {"Jan", "Peb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
            };
            LuotXem = new Axis
            {
                Title = "Lượt xem",
                LabelFormatter = value => value.ToString("N")
            };


        }

        Phim GetMostView(DateTime t1, DateTime t2)
        {
            //get id phim most view
            var temp = DataProvider.Instance.DB.NguoiDung_Xem_Phim.Where(x => x.NgayXem >= t1 && x.NgayXem <= t2)
                                                      .GroupBy(x => x.IdPhim)
                                                      .Select(x => new { Name = x.Key, Total = x.Count() })
                                                      .OrderByDescending(x => x.Total)
                                                      .Take(1);

            if (temp == null)
            {
                return null;
            }
            int idphim = (int)temp.Select(x => x.Name).FirstOrDefault();

            Phim p = DataProvider.Instance.DB.Phims.Where(x => x.Id == idphim).SingleOrDefault();

            //load properties phim
            p.Anh = new Uri(duongdangoc + p.AnhDaiDiens.Single().tenFileAnh);
            p.LuotXem = p.NguoiDung_Xem_Phim.Count;
            p.LuotBinhLuan = p.NguoiDung_BinhLuan_Phim.Count;

            p.LuotDanhGia = p.NguoiDung_DanhGia_Phim.Count;
            if (p.LuotDanhGia == 0)
                p.DiemSo = 0;
            else
            {
                p.DiemSo = Math.Round((double)p.NguoiDung_DanhGia_Phim.Sum(t => t.DiemSo) / p.LuotDanhGia, 1);
            }


            return p;
        }

        Phim GetMostComment(DateTime t1, DateTime t2)
        {
            //get id phim most view
            var temp = DataProvider.Instance.DB.NguoiDung_BinhLuan_Phim.Where(x => x.NgayBinhLuan >= t1 && x.NgayBinhLuan <= t2)
                                                     .GroupBy(x => x.IdPhim)
                                                     .Select(x => new { Name = x.Key, Total = x.Count() })
                                                     .OrderByDescending(x => x.Total)
                                                     .Take(1);
            if (temp == null)
            {
                return null;
            }
            int idphim = (int)temp.Select(x => x.Name).FirstOrDefault();

            Phim p = DataProvider.Instance.DB.Phims.Where(x => x.Id == idphim).SingleOrDefault();
            //load properties phim
            p.Anh = new Uri(duongdangoc + p.AnhDaiDiens.Single().tenFileAnh);
            p.LuotXem = p.NguoiDung_Xem_Phim.Count;
            p.LuotBinhLuan = p.NguoiDung_BinhLuan_Phim.Count;

            p.LuotDanhGia = p.NguoiDung_DanhGia_Phim.Count;
            if (p.LuotDanhGia == 0)
                p.DiemSo = 0;
            else
            {
                p.DiemSo = Math.Round((double)p.NguoiDung_DanhGia_Phim.Sum(t => t.DiemSo) / p.LuotDanhGia, 1);
            }

            return p;
        }

        Phim GetMostRate()
        {
            //get id phim most rate
            var temp = DataProvider.Instance.DB.NguoiDung_DanhGia_Phim
                                                     .GroupBy(x => x.IdPhim)
                                                     .Select(x => new { Name = x.Key, Total = x.Count() })
                                                     .OrderByDescending(x => x.Total)
                                                     .Take(1);
            if (temp == null)
            {
                return null;
            }
            int idphim = (int)temp.Select(x => x.Name).FirstOrDefault();

            Phim p = DataProvider.Instance.DB.Phims.Where(x => x.Id == idphim).SingleOrDefault();

            //load properties phim
            p.Anh = new Uri(duongdangoc + p.AnhDaiDiens.Single().tenFileAnh);
            p.LuotXem = p.NguoiDung_Xem_Phim.Count;
            p.LuotBinhLuan = p.NguoiDung_BinhLuan_Phim.Count;

            p.LuotDanhGia = p.NguoiDung_DanhGia_Phim.Count;
            if (p.LuotDanhGia == 0)
                p.DiemSo = 0;
            else
            {
                p.DiemSo = Math.Round((double)p.NguoiDung_DanhGia_Phim.Sum(t => t.DiemSo) / p.LuotDanhGia, 1);
            }

            return p;
        }
    }
}
