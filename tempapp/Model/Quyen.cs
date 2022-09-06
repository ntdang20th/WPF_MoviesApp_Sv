
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class Quyen : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quyen()
        {
            this.Cua_NguoiDung_Quyen = new HashSet<Cua_NguoiDung_Quyen>();
        }

        private bool _Check;
        public bool Check { get => _Check; set { _Check = value; OnPropertyChanged(); } }

        private string _TenQuyen { get; set; }
        public int Id { get; set; }
        public string TenQuyen { get => _TenQuyen; set { _TenQuyen = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cua_NguoiDung_Quyen> Cua_NguoiDung_Quyen { get; set; }
    }
}

