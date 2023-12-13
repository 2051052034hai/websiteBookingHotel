namespace PhoneShop.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GioHang_62132473
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang_62132473()
        {
            ChiTietGH_62132473 = new HashSet<ChiTietGH_62132473>();
        }

        [Key]
        public int SoHD { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public DateTime? NgayGiaoHang { get; set; }

        public int? MaKH { get; set; }

        public int? MaKH_2 { get; set; }

        public int? MaNV1 { get; set; }

        public int? MaNV0 { get; set; }

        public int TinhTrang { get; set; }

        public double? TongTien { get; set; }

        public int isNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGH_62132473> ChiTietGH_62132473 { get; set; }

        public virtual KhachHang_62132473 KhachHang_62132473 { get; set; }

        public virtual NhanVien_62132473 NhanVien_62132473 { get; set; }

        public virtual NhanVien_62132473 NhanVien_621324731 { get; set; }
        public Dictionary<string, object> TempProperties { get; set; }
        public Dictionary<string, object> TempPropertiesEmp { get; set; }
    }
}
