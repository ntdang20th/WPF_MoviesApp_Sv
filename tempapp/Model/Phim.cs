
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class Phim : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            this.AnhDaiDiens = new HashSet<AnhDaiDien>();
            this.Cua_Phim_Luat = new HashSet<Cua_Phim_Luat>();
            this.Cua_Phim_Studio = new HashSet<Cua_Phim_Studio>();
            this.Cua_Phim_TacGia = new HashSet<Cua_Phim_TacGia>();
            this.Cua_Phim_TheLoai = new HashSet<Cua_Phim_TheLoai>();
            this.NguoiDung_BinhLuan_Phim = new HashSet<NguoiDung_BinhLuan_Phim>();
            this.NguoiDung_DanhGia_Phim = new HashSet<NguoiDung_DanhGia_Phim>();
            this.NguoiDung_Xem_Phim = new HashSet<NguoiDung_Xem_Phim>();
            this.VIDEOs = new HashSet<VIDEO>();
        }

        private Uri _Anh;
        public Uri Anh { get => _Anh; set { _Anh = value; OnPropertyChanged(); } }

        public int? _LuotXem;
        public int? LuotXem { get => _LuotXem; set { _LuotXem = value; OnPropertyChanged(); } }

        public int? _LuotBinhLuan;
        public int? LuotBinhLuan { get => _LuotBinhLuan; set { _LuotBinhLuan = value; OnPropertyChanged(); } }


        public double _DiemSo;
        public double DiemSo { get => _DiemSo; set { _DiemSo = value; OnPropertyChanged(); } }
        public int _LuotDanhGia;
        public int LuotDanhGia { get => _LuotDanhGia; set { _LuotDanhGia = value; OnPropertyChanged(); } }

        public string _TenPhim;
        public Nullable<int> _IdChuDe;
        public Nullable<int> _SoTap;
        public Nullable<int> _ThoiLuong;
        public string _NoiDung;
        public Nullable<int> _NamPhatHanh;
        public Nullable<int> _IdMua;
        public Nullable<int> _IdTrangThai;
        public string _ChatLuong;


        public int Id { get; set; }
        public string TenPhim { get => _TenPhim; set { _TenPhim = value; OnPropertyChanged(); } }
        public Nullable<int> IdChuDe { get => _IdChuDe; set { _IdChuDe = value; OnPropertyChanged(); } }
        public Nullable<int> SoTap { get => _SoTap; set { _SoTap = value; OnPropertyChanged(); } }
        public Nullable<int> ThoiLuong { get => _ThoiLuong; set { _ThoiLuong = value; OnPropertyChanged(); } }
        public string NoiDung { get => _NoiDung; set { _NoiDung = value; OnPropertyChanged(); } }
        public Nullable<int> NamPhatHanh { get => _NamPhatHanh; set { _NamPhatHanh = value; OnPropertyChanged(); } }
        public Nullable<int> IdMua { get => _IdMua; set { _IdMua = value; OnPropertyChanged(); } }
        public Nullable<int> IdTrangThai { get => _IdTrangThai; set { _IdTrangThai = value; OnPropertyChanged(); } }
        public string ChatLuong { get => _ChatLuong; set { _ChatLuong = value; OnPropertyChanged(); } }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhDaiDien> AnhDaiDiens { get; set; }
        public virtual ChuDe ChuDe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cua_Phim_Luat> Cua_Phim_Luat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cua_Phim_Studio> Cua_Phim_Studio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cua_Phim_TacGia> Cua_Phim_TacGia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cua_Phim_TheLoai> Cua_Phim_TheLoai { get; set; }
        public virtual Mua Mua { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        private ICollection<NguoiDung_BinhLuan_Phim> _NguoiDung_BinhLuan_Phim;
        public virtual ICollection<NguoiDung_BinhLuan_Phim> NguoiDung_BinhLuan_Phim { get => _NguoiDung_BinhLuan_Phim; set { _NguoiDung_BinhLuan_Phim = value; OnPropertyChanged(); } }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung_DanhGia_Phim> NguoiDung_DanhGia_Phim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung_Xem_Phim> NguoiDung_Xem_Phim { get; set; }
        public virtual TrangThai TrangThai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIDEO> VIDEOs { get; set; }
    }
}

