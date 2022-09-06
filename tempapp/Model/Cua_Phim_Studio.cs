
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class Cua_Phim_Studio : BaseViewModel
    {

        private Nullable<int> _IdPhim;
        private Nullable<int> _IdStudio;

        public int Id { get; set; }
        public Nullable<int> IdPhim { get => _IdPhim; set { _IdPhim = value; OnPropertyChanged(); } }
        public Nullable<int> IdStudio { get => _IdStudio; set { _IdStudio = value; OnPropertyChanged(); } }

        public virtual Phim Phim { get; set; }
        public virtual Studio Studio { get; set; }
    }
}

