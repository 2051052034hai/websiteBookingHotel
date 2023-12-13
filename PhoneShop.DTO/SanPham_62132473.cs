namespace PhoneShop.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SanPham_62132473
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham_62132473()
        {
            ChiTietGH_62132473 = new HashSet<ChiTietGH_62132473>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(250)]
        public string TenSP { get; set; }

        public string Mota { get; set; }

        [StringLength(250)]
        public string AnhSP { get; set; }

        public double DonGia { get; set; }

        public int LoaiSP { get; set; }

        public int? SLTonKho { get; set; }

        public int? GiamGia { get; set; }
        public int xoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGH_62132473> ChiTietGH_62132473 { get; set; }

        public virtual LoaiSP_62132473 LoaiSP_62132473 { get; set; }
    }
}
