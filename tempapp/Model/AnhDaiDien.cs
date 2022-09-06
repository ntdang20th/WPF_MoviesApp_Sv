
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class AnhDaiDien : BaseViewModel
    {
        public Nullable<int> _IdPhim;
        public string _tenFileAnh;
        public int Id { get; set; }
        public Nullable<int> IdPhim { get => _IdPhim; set { _IdPhim = value; OnPropertyChanged(); } }
        public string tenFileAnh { get => _tenFileAnh; set { _tenFileAnh = value; OnPropertyChanged(); } }
        public virtual Phim Phim { get; set; }
    }
}

