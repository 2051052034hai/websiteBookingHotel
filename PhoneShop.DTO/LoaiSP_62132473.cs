namespace PhoneShop.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoaiSP_62132473
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSP_62132473()
        {
            SanPham_62132473 = new HashSet<SanPham_62132473>();
        }

        [Key]
        public int MaLoaiSP { get; set; }

        [Required]
        [StringLength(250)]
        public string TenLoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham_62132473> SanPham_62132473 { get; set; }
    }
}
