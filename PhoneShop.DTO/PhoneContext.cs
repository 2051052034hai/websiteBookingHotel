using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PhoneShop.DTO
{
    public partial class PhoneContext : DbContext
    {
        public PhoneContext()
            : base("name=PhoneContext")
        {
        }

        public virtual DbSet<ChiTietGH_62132473> ChiTietGH_62132473 { get; set; }
        public virtual DbSet<GioHang_62132473> GioHang_62132473 { get; set; }
        public virtual DbSet<KhachHang_62132473> KhachHang_62132473 { get; set; }
        public virtual DbSet<LoaiSP_62132473> LoaiSP_62132473 { get; set; }
        public virtual DbSet<NhanVien_62132473> NhanVien_62132473 { get; set; }
        public virtual DbSet<QuyenSD_62132473> QuyenSD_62132473 { get; set; }
        public virtual DbSet<SanPham_62132473> SanPham_62132473 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GioHang_62132473>()
                .HasMany(e => e.ChiTietGH_62132473)
                .WithRequired(e => e.GioHang_62132473)
                .HasForeignKey(e => e.SoDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang_62132473>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang_62132473>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang_62132473>()
                .HasMany(e => e.GioHang_62132473)
                .WithRequired(e => e.KhachHang_62132473)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSP_62132473>()
                .HasMany(e => e.SanPham_62132473)
                .WithRequired(e => e.LoaiSP_62132473)
                .HasForeignKey(e => e.LoaiSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien_62132473>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien_62132473>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien_62132473>()
                .HasMany(e => e.GioHang_62132473)
                .WithRequired(e => e.NhanVien_62132473)
                .HasForeignKey(e => e.MaNV1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien_62132473>()
                .HasMany(e => e.GioHang_621324731)
                .WithRequired(e => e.NhanVien_621324731)
                .HasForeignKey(e => e.MaNV0)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenSD_62132473>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<QuyenSD_62132473>()
                .HasMany(e => e.KhachHang_62132473)
                .WithOptional(e => e.QuyenSD_62132473)
                .HasForeignKey(e => e.QuyenSD);

            modelBuilder.Entity<QuyenSD_62132473>()
                .HasMany(e => e.NhanVien_62132473)
                .WithOptional(e => e.QuyenSD_62132473)
                .HasForeignKey(e => e.QuyenSD);

            modelBuilder.Entity<SanPham_62132473>()
                .HasMany(e => e.ChiTietGH_62132473)
                .WithRequired(e => e.SanPham_62132473)
                .WillCascadeOnDelete(false);
        }
    }
}
