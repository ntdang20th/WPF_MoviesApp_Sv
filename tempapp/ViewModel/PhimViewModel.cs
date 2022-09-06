using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using tempapp.Model;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;

namespace tempapp.ViewModel
{
    class PhimViewModel : BaseViewModel
    {
        public static string duongdangoc = "D:\\data\\";
        double diem;
        int count;

        #region List
        public ObservableCollection<Phim> _ListPhim;
        public ObservableCollection<Phim> ListPhim { get => _ListPhim; set { _ListPhim = value; OnPropertyChanged(); } }

        public ObservableCollection<ChuDe> _ListChuDe;
        public ObservableCollection<ChuDe> ListChuDe { get => _ListChuDe; set { _ListChuDe = value; OnPropertyChanged(); } }

        public ObservableCollection<Mua> _ListMua;
        public ObservableCollection<Mua> ListMua { get => _ListMua; set { _ListMua = value; OnPropertyChanged(); } }

        public ObservableCollection<TacGia> _ListTacGia;
        public ObservableCollection<TacGia> ListTacGia { get => _ListTacGia; set { _ListTacGia = value; OnPropertyChanged(); } }

        public ObservableCollection<Studio> _ListStudio;
        public ObservableCollection<Studio> ListStudio { get => _ListStudio; set { _ListStudio = value; OnPropertyChanged(); } }

        public ObservableCollection<TrangThai> _ListTrangThai;
        public ObservableCollection<TrangThai> ListTrangThai { get => _ListTrangThai; set { _ListTrangThai = value; OnPropertyChanged(); } }

        public ObservableCollection<TheLoai> _ListTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => _ListTheLoai; set { _ListTheLoai = value; OnPropertyChanged(); } }

        public ObservableCollection<Luat> _ListLuat;
        public ObservableCollection<Luat> ListLuat { get => _ListLuat; set { _ListLuat = value; OnPropertyChanged(); } }

        public ObservableCollection<VIDEO> _ListVideo;
        public ObservableCollection<VIDEO> ListVideo { get => _ListVideo; set { _ListVideo = value; OnPropertyChanged(); } }
        #endregion


        #region Properties

        public string _TenPhim;
        public string TenPhim { get => _TenPhim; set { _TenPhim = value; OnPropertyChanged(); } }

        public int? _SoTap;
        public int? SoTap { get => _SoTap; set { _SoTap = value; OnPropertyChanged(); } }

        public int? _ThoiLuong;
        public int? ThoiLuong { get => _ThoiLuong; set { _ThoiLuong = value; OnPropertyChanged(); } }

        public string _NoiDung;
        public string NoiDung { get => _NoiDung; set { _NoiDung = value; OnPropertyChanged(); } }

        public int? _NamPhatHanh;
        public int? NamPhatHanh { get => _NamPhatHanh; set { _NamPhatHanh = value; OnPropertyChanged(); } }

        public string _ChatLuong;
        public string ChatLuong { get => _ChatLuong; set { _ChatLuong = value; OnPropertyChanged(); } }

        public int? _LuotXem;
        public int? LuotXem { get => _LuotXem; set { _LuotXem = value; OnPropertyChanged(); } }

        public int? _LuotBinhLuan;
        public int? LuotBinhLuan { get => _LuotBinhLuan; set { _LuotBinhLuan = value; OnPropertyChanged(); } }

        public string _DiemSo;
        public string DiemSo { get => _DiemSo; set { _DiemSo = value; OnPropertyChanged(); } }

        public string _fileAnh;
        public string fileAnh { get => _fileAnh; set { _fileAnh = value; OnPropertyChanged(); } }
        public bool _CheckAn;
        public bool CheckAn { get => _CheckAn; set { _CheckAn = value; OnPropertyChanged(); } }
        #endregion


        #region Selected Items

        public Phim _SelectedItem;
        public Phim SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TenPhim = SelectedItem.TenPhim;
                    SoTap = SelectedItem.SoTap;
                    ThoiLuong = SelectedItem.ThoiLuong;
                    NoiDung = SelectedItem.NoiDung;
                    NamPhatHanh = SelectedItem.NamPhatHanh;
                    ChatLuong = SelectedItem.ChatLuong;

                    LuotXem = SelectedItem.NguoiDung_Xem_Phim.Count;
                    LuotBinhLuan = SelectedItem.NguoiDung_BinhLuan_Phim.Count;
                    
                    count = SelectedItem.NguoiDung_DanhGia_Phim.Count;
                    diem = (double)SelectedItem.NguoiDung_DanhGia_Phim.Sum(p => p.DiemSo);
                    DiemSo = diem + " / " + count; 

                    SelectedChuDe = SelectedItem.ChuDe;
                    SelectedMua= SelectedItem.Mua;
                    SelectedTrangThai = SelectedItem.TrangThai;

                    GetPathImage();

                    //load cbb theer loai
                    GetListTheLoai();
                    GetListTacGia();
                    GetListStudio();

                    //CheckTheLoai = SelectedTheLoaiList.Contains()
                    ListVideo = new ObservableCollection<VIDEO>(DataProvider.Instance.DB.VIDEOs.Where(t => t.IdPhim == SelectedItem.Id));
                }
            }
        }

        public VIDEO _SelectedTapPhim;
        public VIDEO SelectedTapPhim { get => _SelectedTapPhim; set { _SelectedTapPhim = value; OnPropertyChanged(); } }

        public ChuDe _SelectedChuDe;
        public ChuDe SelectedChuDe { get => _SelectedChuDe; set { _SelectedChuDe = value; OnPropertyChanged(); } }

        public BitmapImage _SelectedImage;
        public BitmapImage SelectedImage { get => _SelectedImage; set { _SelectedImage = value; OnPropertyChanged(); } }

        public Mua _SelectedMua;
        public Mua SelectedMua { get => _SelectedMua; set { _SelectedMua = value; OnPropertyChanged(); } }

        public TrangThai _SelectedTrangThai;
        public TrangThai SelectedTrangThai { get => _SelectedTrangThai; set { _SelectedTrangThai = value; OnPropertyChanged(); } }

        public ObservableCollection<TacGia> _SelectedTacGiaList;
        public ObservableCollection<TacGia> SelectedTacGiaList { get => _SelectedTacGiaList; set { _SelectedTacGiaList = value; OnPropertyChanged(); } }

        public ObservableCollection<Studio> _SelectedStudioList;
        public ObservableCollection<Studio> SelectedStudioList { get => _SelectedStudioList; set { _SelectedStudioList = value; OnPropertyChanged(); } }

        public ObservableCollection<TheLoai> _SelectedTheLoaiList;
        public ObservableCollection<TheLoai> SelectedTheLoaiList { get => _SelectedTheLoaiList; set { _SelectedTheLoaiList = value; OnPropertyChanged(); } }

        public ObservableCollection<Luat> _SelectedLuatList;
        public ObservableCollection<Luat> SelectedLuatList { get => _SelectedLuatList; set { _SelectedLuatList = value; OnPropertyChanged(); } }
        #endregion


        #region Command
        public ICommand Them_Command { get; set; }
        public ICommand Sua_Command { get; set; }
        public ICommand ChonAnh_Command { get; set; }

        public ICommand ChonVideo_Command { get; set; }
        public ICommand PlayVideo_Command { get; set; }
        public ICommand EnterCommand { get; set; }
        #endregion

        public PhimViewModel()
        {
            ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.DB.Phims);
            ListChuDe = new ObservableCollection<ChuDe>(DataProvider.Instance.DB.ChuDes);
            ListMua = new ObservableCollection<Mua>(DataProvider.Instance.DB.Muas);
            ListTacGia = new ObservableCollection<TacGia>(DataProvider.Instance.DB.TacGias);
            ListStudio = new ObservableCollection<Studio>(DataProvider.Instance.DB.Studios);
            ListTrangThai = new ObservableCollection<TrangThai>(DataProvider.Instance.DB.TrangThais);
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.DB.TheLoais);
            ListLuat = new ObservableCollection<Luat>(DataProvider.Instance.DB.Luats);


            SelectedTheLoaiList = new ObservableCollection<TheLoai>();
            SelectedTacGiaList = new ObservableCollection<TacGia>();
            SelectedStudioList = new ObservableCollection<Studio>();

            
            Them_Command = new RelayCommand<object>((p) =>
            {
                //check: tên, chude, trang thai, noi dung, tac gia, theloai, studio


                if (String.IsNullOrEmpty(TenPhim) || String.IsNullOrEmpty(NoiDung) || SelectedChuDe == null || SelectedTrangThai == null || !checkNullTheLoai() || !checkNullTacGia() || !CheckNullStudio())
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                //các thuộc tính cảu phim: Tên phim, chủ đề (ID), số tập, thời lượng, Id lượt bình luận - đánh giá - lượt xem (cố định), nội dung, năm phát hành, Id mùa, id trrang thái, cchát lượng, ẩn phim.  
                #region tạo phim 

                var phim = new Phim()
                {
                    TenPhim = TenPhim,
                    IdChuDe = SelectedChuDe.Id,
                    SoTap = SoTap, ThoiLuong = ThoiLuong,
                    NoiDung = NoiDung,
                    NamPhatHanh = NamPhatHanh,
                    IdMua = SelectedMua.Id,
                    IdTrangThai = SelectedTrangThai.Id,
                    ChatLuong = ChatLuong
                };

                DataProvider.Instance.DB.Phims.Add(phim);
                DataProvider.Instance.DB.SaveChanges();
                #endregion


                //thêm ràng buộc thể loại, tác giả, stdio, luat
                #region các colection thể loại, tác giả, stdio + ảnh + list video rỗng
                Cua_Phim_Luat luatphim;
                foreach (Luat t in ListLuat)
                {
                    if (t.Check == true)
                    {
                        luatphim = new Cua_Phim_Luat()
                        {
                            IdPhim = phim.Id,
                            IdLuat = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_Luat.Add(luatphim);
                    }
                }

                Cua_Phim_TheLoai theloaiphim;
                foreach (TheLoai t in ListTheLoai)
                {
                    if (t.Check == true)
                    {
                        theloaiphim = new Cua_Phim_TheLoai()
                        {
                            IdPhim = phim.Id,
                            IdTheLoai = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_TheLoai.Add(theloaiphim);
                    }
                }

                Cua_Phim_TacGia tacgiaphim;
                foreach (TacGia t in ListTacGia)
                {
                    if (t.Check == true)
                    {
                        tacgiaphim = new Cua_Phim_TacGia()
                        {
                            IdPhim = phim.Id,
                            IdTacGia = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_TacGia.Add(tacgiaphim);
                    }

                }

                Cua_Phim_Studio studiophim;
                foreach (Studio t in ListStudio)
                {
                    if (t.Check == true)
                    {
                        studiophim = new Cua_Phim_Studio()
                        {
                            IdPhim = phim.Id,
                            IdStudio = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_Studio.Add(studiophim);
                    }

                }

                //them list video va anh dai dien (rong)
                AnhDaiDien d = new AnhDaiDien() { IdPhim = phim.Id, tenFileAnh = "" };
                DataProvider.Instance.DB.AnhDaiDiens.Add(d);

                VIDEO tapphim;
                for(int i = 1; i <= SoTap; i++)
                {
                    tapphim = new VIDEO() { IdPhim = phim.Id, SoTap = "Tập " + i, tenFileVideo = "" };
                    DataProvider.Instance.DB.VIDEOs.Add(tapphim);
                }
                DataProvider.Instance.DB.SaveChanges();
                #endregion



                ListPhim.Add(phim);

                MessageBox.Show("Đã thêm thành công!");
            });

            Sua_Command = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(TenPhim) || String.IsNullOrEmpty(NoiDung) || SelectedChuDe == null || SelectedTrangThai == null || !checkNullTheLoai() || !checkNullTacGia() || !CheckNullStudio())
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                //cập nhật các thông tin cơ bản
                #region cập nhật cơ bản
                var phimCu = DataProvider.Instance.DB.Phims.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();
                phimCu.TenPhim = TenPhim;
                phimCu.IdChuDe = SelectedChuDe.Id;
                int? sotapcu = phimCu.SoTap;
                phimCu.SoTap = SoTap;
                phimCu.ThoiLuong = ThoiLuong;
                phimCu.NoiDung = NoiDung;
                phimCu.NamPhatHanh = NamPhatHanh;
                phimCu.IdMua = SelectedMua.Id;
                phimCu.IdTrangThai = SelectedTrangThai.Id;
                phimCu.ChatLuong = ChatLuong;
                #endregion


                //xóa các giá trị trung gian cũ đi, ađd cái mới
                #region update thể loại, tác giả, studio
                //xua luat
                var luatphim = DataProvider.Instance.DB.Cua_Phim_Luat.Where(t => t.IdPhim == SelectedItem.Id).ToList();
                foreach (Cua_Phim_Luat i in luatphim)
                {
                    DataProvider.Instance.DB.Cua_Phim_Luat.Remove(i);
                }

                //xoa khoa phu: Cua_Phim_TacGia
                var tacgiaphim = DataProvider.Instance.DB.Cua_Phim_TacGia.Where(t => t.IdPhim == SelectedItem.Id).ToList();
                foreach (Cua_Phim_TacGia i in tacgiaphim)
                {
                    DataProvider.Instance.DB.Cua_Phim_TacGia.Remove(i);
                }

                //xoa khoa phu: Cua_Phim_TheLoai
                var theloaiphim = DataProvider.Instance.DB.Cua_Phim_TheLoai.Where(t => t.IdPhim == SelectedItem.Id).ToList();
                foreach (Cua_Phim_TheLoai i in theloaiphim)
                {
                    DataProvider.Instance.DB.Cua_Phim_TheLoai.Remove(i);
                }

                //xoa khoa phu: Cua_Phim_Studio
                var studiophim = DataProvider.Instance.DB.Cua_Phim_Studio.Where(t => t.IdPhim == SelectedItem.Id).ToList();
                foreach (Cua_Phim_Studio i in studiophim)
                {
                    DataProvider.Instance.DB.Cua_Phim_Studio.Remove(i);
                }
                DataProvider.Instance.DB.SaveChanges();

                //them luat
                Cua_Phim_Luat luatphimmoi;
                foreach (Luat t in ListLuat)
                {
                    if (t.Check == true)
                    {
                        luatphimmoi = new Cua_Phim_Luat()
                        {
                            IdPhim = phimCu.Id,
                            IdLuat = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_Luat.Add(luatphimmoi);
                    }
                }
                //thêm ràng buộc thể loại, tác giả, stdio
                Cua_Phim_TheLoai theloaiphimmoi;
                foreach (TheLoai t in ListTheLoai)
                {
                    if (t.Check == true)
                    {
                        theloaiphimmoi = new Cua_Phim_TheLoai()
                        {
                            IdPhim = phimCu.Id,
                            IdTheLoai = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_TheLoai.Add(theloaiphimmoi);
                    }
                }

                Cua_Phim_TacGia tacgiaphimmoi;
                foreach (TacGia t in ListTacGia)
                {
                    if (t.Check == true)
                    {
                        tacgiaphimmoi = new Cua_Phim_TacGia()
                        {
                            IdPhim = phimCu.Id,
                            IdTacGia = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_TacGia.Add(tacgiaphimmoi);
                    }
                }

                Cua_Phim_Studio studiophimmoi;
                foreach (Studio t in ListStudio)
                {
                    if (t.Check == true)
                    {
                        studiophimmoi = new Cua_Phim_Studio()
                        {
                            IdPhim = phimCu.Id,
                            IdStudio = t.Id
                        };
                        DataProvider.Instance.DB.Cua_Phim_Studio.Add(studiophimmoi);
                    }
                }

                DataProvider.Instance.DB.SaveChanges();
                #endregion

                //update số tập phim trong bảng video
                #region update số lượng tập phim 
                if (SoTap == sotapcu)
                    return;
                //xoa lisst video cu
                var dsphim = DataProvider.Instance.DB.VIDEOs.Where(t => t.IdPhim == SelectedItem.Id).ToList();
                foreach(VIDEO i in dsphim )
                {
                    DataProvider.Instance.DB.VIDEOs.Remove(i);
                }
                DataProvider.Instance.DB.SaveChanges();

                //them list video
                VIDEO tapphim;
                for (int i = 1; i <= SoTap; i++)
                {
                    tapphim = new VIDEO() { IdPhim = SelectedItem.Id, SoTap = "Tập " + i, tenFileVideo = "" };
                    DataProvider.Instance.DB.VIDEOs.Add(tapphim);
                }
                DataProvider.Instance.DB.SaveChanges();
                #endregion

                MessageBox.Show("Đã sửa thành công!");
            });

            ChonAnh_Command = new RelayCommand<Image>((p) =>
            {
                if (SelectedItem==null)
                    return false;
                return true;
            }, (p) =>
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                if (openfiledialog.ShowDialog() == true)
                {
                    SelectedImage = new BitmapImage(new Uri(openfiledialog.FileName));

                    AnhDaiDien x = DataProvider.Instance.DB.AnhDaiDiens.Where(a => a.IdPhim == SelectedItem.Id).SingleOrDefault();
                    x.tenFileAnh = TenPhim + "\\images\\" + openfiledialog.SafeFileName;
                    DataProvider.Instance.DB.SaveChanges();

                    string folderfilm = duongdangoc + TenPhim + "\\images";

                    System.IO.Directory.CreateDirectory(folderfilm);
                    System.IO.DirectoryInfo di = new DirectoryInfo(folderfilm);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (file.Name != openfiledialog.SafeFileName)
                            try
                            {
                            file.Delete();
                            }
                            catch { };
                    }
                    try
                    {
                        File.Copy(openfiledialog.FileName, duongdangoc + x.tenFileAnh);
                    }
                    catch { }
                }
            });

            ChonVideo_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedTapPhim == null)
                    return false;
                return true; 
            }, (p) =>
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                if (openfiledialog.ShowDialog() == true)
                {
                    var x = DataProvider.Instance.DB.VIDEOs.Where(v => v.Id == SelectedTapPhim.Id).SingleOrDefault();
                    x.tenFileVideo = TenPhim+"\\videos\\" + SelectedTapPhim.SoTap +"\\"+ openfiledialog.SafeFileName;
                    DataProvider.Instance.DB.SaveChanges();

                    string folderfilm = duongdangoc + TenPhim + "\\videos\\" +SelectedTapPhim.SoTap;

                    System.IO.Directory.CreateDirectory(folderfilm);
                    System.IO.DirectoryInfo di = new DirectoryInfo(folderfilm);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        //if (file.Name != openfiledialog.SafeFileName)
                            //try
                            //{
                                file.Delete();
                            //}
                            //catch { };
                    }
                    //try
                    //{
                    File.Copy(openfiledialog.FileName, duongdangoc + x.tenFileVideo);
                    //}
                    //catch {}
                    
                }
            });

            PlayVideo_Command = new RelayCommand<object>((p) =>
            {
                if (SelectedTapPhim == null || SelectedTapPhim.tenFileVideo=="")
                    return false;
                return true;
            }, (p) =>
            {
                PlayFilmWindow pfw = new PlayFilmWindow(SelectedTapPhim.tenFileVideo);
                pfw.ShowDialog();
            });

            EnterCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.DB.Phims.Where(t => t.TenPhim.Contains(p.Text)).ToList());
            });
        }

        #region hàm
        //check null lít: 1: theloai, 2: tac gia, 3: studio
        bool CheckNullStudio()
        {
            foreach (Studio t in ListStudio)
            {
                if (t.Check == true)
                    return true;
            }

            return false;
        }

        bool checkNullTheLoai()
        {
            foreach (TheLoai t in ListTheLoai)
            {
                if (t.Check == true)
                    return true;
            }
            return false;
        }

        bool checkNullTacGia()
        {
            foreach (TacGia t in ListTacGia)
            {
                if (t.Check == true)
                    return true;
            }
            return false;
        }

        //get anh phim
        void GetPathImage()
        {
            AnhDaiDien x = DataProvider.Instance.DB.AnhDaiDiens.Where(t => t.IdPhim == SelectedItem.Id).SingleOrDefault();
            if (x == null || x.tenFileAnh=="")
            {
                fileAnh = "";
                return;
            }
            fileAnh = x.tenFileAnh;
            SelectedImage = new BitmapImage(new Uri(duongdangoc + fileAnh));
        }
        //get list luat
        void GetListLuat()
        {
            Luat tam;

            List<Cua_Phim_Luat> x = DataProvider.Instance.DB.Cua_Phim_Luat.Where(t => t.IdPhim == SelectedItem.Id).ToList();

            //lấy danh sách các thể loại của phim

            SelectedTheLoaiList.Clear();
            foreach (Cua_Phim_Luat tl in x)
            {
                tam = DataProvider.Instance.DB.Luats.Where(t => t.Id == tl.IdLuat).SingleOrDefault();
                tam.Check = true;
                SelectedLuatList.Add(tam);

            }

            //danh sách tất cả thể loại chưa đuọcw checked: ListTheLoai

            //tiến hành check nè
            foreach (TheLoai t in ListTheLoai)
            {
                t.Check = false;
                if (SelectedTheLoaiList.Contains(t))
                {
                    t.Check = true;
                }
            }
        }

        //get lít the loai
        void GetListTheLoai()
        {
            TheLoai tam;

            List<Cua_Phim_TheLoai> x = DataProvider.Instance.DB.Cua_Phim_TheLoai.Where(t => t.IdPhim == SelectedItem.Id).ToList();

            //lấy danh sách các thể loại của phim

            SelectedTheLoaiList.Clear();
            foreach (Cua_Phim_TheLoai tl in x)
            {
                tam = DataProvider.Instance.DB.TheLoais.Where(t => t.Id == tl.IdTheLoai).SingleOrDefault();
                tam.Check = true;
                SelectedTheLoaiList.Add(tam);

            }

            //danh sách tất cả thể loại chưa đuọcw checked: ListTheLoai

            //tiến hành check nè
            foreach(TheLoai t in ListTheLoai)
            {
                t.Check = false;
                if (SelectedTheLoaiList.Contains(t))
                {
                    t.Check = true;
                }
            }
        }

        //gẻt lít tac gia
        void GetListTacGia()
        {
            TacGia tam;

            List<Cua_Phim_TacGia> x = DataProvider.Instance.DB.Cua_Phim_TacGia.Where(t => t.IdPhim == SelectedItem.Id).ToList();

            //lấy danh sách các thể loại của phim

            SelectedTacGiaList.Clear();
            foreach (Cua_Phim_TacGia tl in x)
            {
                tam = DataProvider.Instance.DB.TacGias.Where(t => t.Id == tl.IdTacGia).SingleOrDefault();
                tam.Check = true;
                SelectedTacGiaList.Add(tam);

            }

            //danh sách tất cả thể loại chưa đuọcw checked: ListTacGia

            //tiến hành check nè
            foreach (TacGia t in ListTacGia)
            {
                t.Check = false;
                if (SelectedTacGiaList.Contains(t))
                {
                    t.Check = true;
                }
            }
        }
        //gẻt lít Stdio
        void GetListStudio()
        {
            Studio tam;

            List<Cua_Phim_Studio> x = DataProvider.Instance.DB.Cua_Phim_Studio.Where(t => t.IdPhim == SelectedItem.Id).ToList();

            //lấy danh sách các thể loại của phim

            SelectedStudioList.Clear();
            foreach (Cua_Phim_Studio tl in x)
            {
                tam = DataProvider.Instance.DB.Studios.Where(t => t.Id == tl.IdStudio).SingleOrDefault();
                tam.Check = true;
                SelectedStudioList.Add(tam);

            }

            //danh sách tất cả thể loại chưa đuọcw checked: ListTacGia

            //tiến hành check nè
            foreach (Studio t in ListStudio)
            {
                t.Check = false;
                if (SelectedStudioList.Contains(t))
                {
                    t.Check = true;
                }
            }
        }
        #endregion
    }
}


