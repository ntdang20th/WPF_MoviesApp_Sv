
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;
    public partial class ChuDe : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuDe()
        {
            this.Phims = new HashSet<Phim>();
        }

        private string _TenChuDe;

        public int Id { get; set; }
        public string TenChuDe { get => _TenChuDe; set { _TenChuDe = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim> Phims { get; set; }
    }
}

