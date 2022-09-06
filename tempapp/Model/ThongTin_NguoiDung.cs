namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class ThongTin_NguoiDung : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTin_NguoiDung()
        {
            this.NguoiDungs = new HashSet<NguoiDung>();
        }

        private string _Ho_HoLot;
        private string _Ten;
        private Nullable<System.DateTime> _NgaySinh;
        private string _Email;


        public int Id { get; set; }
        public string Ho_HoLot { get => _Ho_HoLot; set { _Ho_HoLot = value; OnPropertyChanged(); } }
        public string Ten { get => _Ten; set { _Ten = value; OnPropertyChanged(); } }
        public Nullable<System.DateTime> NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}