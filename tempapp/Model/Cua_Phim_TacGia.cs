
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class Cua_Phim_TacGia : BaseViewModel
    {
        public Nullable<int> _IdPhim;
        public Nullable<int> _IdTacGia;

        public int Id { get; set; }
        public Nullable<int> IdPhim { get => _IdPhim; set { _IdPhim = value; OnPropertyChanged(); } }
        public Nullable<int> IdTacGia { get => _IdTacGia; set { _IdTacGia = value; OnPropertyChanged(); } }

        public virtual Phim Phim { get; set; }
        public virtual TacGia TacGia { get; set; }
    }
}


