//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class NguoiDung_BinhLuan_Phim : BaseViewModel
    {
        private Nullable<System.DateTime> _NgayBinhLuan;
        private Nullable<int> _IdNguoiDung;
        private Nullable<int> _IdPhim;
        private string _NoiDung;

        public int Id { get; set; }
        public Nullable<System.DateTime> NgayBinhLuan { get => _NgayBinhLuan; set { _NgayBinhLuan = value; OnPropertyChanged(); } }
        public Nullable<int> IdNguoiDung { get => _IdNguoiDung; set { _IdNguoiDung = value; OnPropertyChanged(); } }
        public Nullable<int> IdPhim { get => _IdPhim; set { _IdPhim = value; OnPropertyChanged(); } }
        public string NoiDung { get => _NoiDung; set { _NoiDung = value; OnPropertyChanged(); } }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual Phim Phim { get; set; }
    }
}

