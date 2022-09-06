
namespace tempapp.Model
{
    using System;
    using System.Collections.Generic;
    using tempapp.ViewModel;

    public partial class Mua : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mua()
        {
            this.Phims = new HashSet<Phim>();
        }

        private string _TenMua;

        public int Id { get; set; }
        public string TenMua { get => _TenMua; set { _TenMua = value; OnPropertyChanged(); } }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim> Phims { get; set; }
    }
}

