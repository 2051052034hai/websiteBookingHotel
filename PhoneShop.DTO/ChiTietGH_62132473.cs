namespace PhoneShop.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTietGH_62132473
    {
        public ChiTietGH_62132473()
        {
        }

        public ChiTietGH_62132473(int SoLuong, float DonGia, int SanPhamID, SanPham_62132473 SanPham)
        {
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
            this.MaSP = SanPhamID;
            this.SanPham_62132473 = SanPham;
        }

        public ChiTietGH_62132473(int ID, int SoLuong, float DonGia, int SoDH)
        {
            this.ID = ID;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
            this.SoDH = SoDH;
        }

        public ChiTietGH_62132473(int id, int SoLuong)
        {
            this.ID = id;
            this.SoLuong = SoLuong;
        }
        public int ID { get; set; }

        public int SoDH { get; set; }

        public int MaSP { get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }

        public virtual GioHang_62132473 GioHang_62132473 { get; set; }

        public virtual SanPham_62132473 SanPham_62132473 { get; set; }
    }
}
