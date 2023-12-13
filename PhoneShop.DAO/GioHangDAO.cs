using PhoneShop.DTO;
using PhoneShop.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.DAO
{
    public class GioHangDAO
    {
        private readonly PhoneContext context;

        public GioHangDAO()
        {
            context = new PhoneContext();
        }

        public int Create(GioHang_62132473 bill, List<ChiTietGH_62132473> billDetails)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Add bill to database
                    context.GioHang_62132473.Add(bill);
                    context.SaveChanges();
                    SanPhamDAO productDAO = new SanPhamDAO();
                    // Assign ID to each BillDetail
                    foreach (var billDetail in billDetails)
                    {
                        billDetail.SoDH = bill.SoHD;
                        if (billDetail.SoLuong > 0)
                        {
                            SanPham_62132473 product = productDAO.GetSanPham_62132473ById(billDetail.SanPham_62132473.MaSP);
                            product.SLTonKho -= (int)billDetail.SoLuong;
                            productDAO.Update(product);
                        }
                        billDetail.SanPham_62132473 = null;
                    }


                    // Add bill details to database
                    context.ChiTietGH_62132473.AddRange(billDetails);
                    context.SaveChanges();

                    transaction.Commit();
                    return bill.SoHD;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public GioHang_62132473 GetBillById(int SoHD)
        {
            return context.GioHang_62132473.FirstOrDefault(b => b.SoHD == SoHD);
        }

        public List<GioHang_62132473> GetAll()
        {
            var gioHangList  = context.GioHang_62132473.Where(gh => gh.TinhTrang == 0).ToList();

            foreach (var gioHang in gioHangList)
            {
                if (gioHang.MaKH_2 != null)
                {
                    var NhanVien = context.NhanVien_62132473.FirstOrDefault(nv => nv.MaNV == gioHang.MaKH_2);
                    if(NhanVien != null)
                    {
                        gioHang.TempProperties = new Dictionary<string, object>
                            {
                              { "KhachHang2", NhanVien.HoTen }
                             };
                       
                    }
                }
            }

            return gioHangList;
        }

        public List<GioHang_62132473> GetAllAdmin()
        {
            var gioHangList = context.GioHang_62132473.ToList();

            foreach (var gioHang in gioHangList)
            {
                if (gioHang.MaKH_2 != null)
                {
                    var NhanVien = context.NhanVien_62132473.FirstOrDefault(nv => nv.MaNV == gioHang.MaKH_2);
                   
                    if (NhanVien != null)
                    {
                        gioHang.TempProperties = new Dictionary<string, object>
                            {
                              { "KhachHang2", NhanVien.HoTen }
                             };

                    }
                }

                if(gioHang.MaNV0 != null && gioHang.MaNV1 != null)
                {
                    var NhanVien0 = context.NhanVien_62132473.FirstOrDefault(nv => nv.MaNV == gioHang.MaNV0);
                    var NhanVien1 = context.NhanVien_62132473.FirstOrDefault(nv => nv.MaNV == gioHang.MaNV1);
                    if (NhanVien0 != null && NhanVien1 != null)
                    {
                        gioHang.TempPropertiesEmp = new Dictionary<string, object>
                            {
                              { "NhanVien0", NhanVien0.HoTen },
                               { "NhanVien1", NhanVien1.HoTen }
                             };

                    }
                }
            }

            return gioHangList;
        }

        public List<GioHang_62132473> GetAllRevenue()
        {
            var gioHangList = context.GioHang_62132473.Where(gh => gh.TinhTrang == 2).ToList();
            return gioHangList;
        }
        public List<GioHang_62132473> GetBillsByCustomerId(int MaKH)
        {
            return context.GioHang_62132473.Where(b => b.MaKH == MaKH).ToList();
        }

        public int Update(GioHang_62132473 bill)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingBill = context.GioHang_62132473.Find(bill.SoHD);

                    if (existingBill != null)
                    {
                        existingBill.NgayGiaoHang = bill.NgayGiaoHang;
                        existingBill.MaNV0 = bill.MaNV0;
                        existingBill.MaNV1 = bill.MaNV1;
                        existingBill.TinhTrang = bill.TinhTrang;
                    }

                    context.SaveChanges();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public int UpdateAdmin(GioHang_62132473 bill)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingBill = context.GioHang_62132473.Find(bill.SoHD);

                    if (existingBill != null)
                    {
                        existingBill.TinhTrang = bill.TinhTrang;
                    }

                    context.SaveChanges();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public int Delete(GioHang_62132473 bill)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.GioHang_62132473.Remove(bill);
                    context.SaveChanges();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
      
    }

}