namespace PhoneShop.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhanVien_62132473
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien_62132473()
        {
            GioHang_62132473 = new HashSet<GioHang_62132473>();
            GioHang_621324731 = new HashSet<GioHang_62132473>();
        }

        public NhanVien_62132473(string HoTen, string DiaChi, string SDT, string MatKhau, string Email, int QuyenSD)
        {
            this.HoTen = HoTen;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
            this.MatKhau = MatKhau;
            this.email = Email;
            this.QuyenSD = QuyenSD;
            this.GioHang_62132473 = new HashSet<GioHang_62132473>();
        }

        [Key]
        public int MaNV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        public int xoa { get; set; }
        public string DiaChi { get; set; }
        public int? QuyenSD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang_62132473> GioHang_62132473 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang_62132473> GioHang_621324731 { get; set; }

        public virtual QuyenSD_62132473 QuyenSD_62132473 { get; set; }
    }
}
