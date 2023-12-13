using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.DTO;
using PhoneShop.BUS;
namespace PhoneShop.Areas.Admin.Controllers
{
    public class Home_62132473Controller : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            LoaiSP_62132473 cate = new LoaiSP_62132473();
            ChiTietGioHangBUS busDetail = new ChiTietGioHangBUS();
            LoaiSPBUS cateBus = new LoaiSPBUS();
            KhachHangBUS customerBus = new KhachHangBUS();
            GioHang_62132473 cart = new GioHang_62132473();
            GioHangBUS busBill = new GioHangBUS();

            // Tính toán doanh thu cho từng loại sản phẩm
            List<ChiTietGH_62132473> BillDetailList = new List<ChiTietGH_62132473>();
            List<SanPham_62132473> products = new List<SanPham_62132473>();
            List<GioHang_62132473> bills = new List<GioHang_62132473>();

            BillDetailList = busDetail.GetAll();

            var groupedByType = BillDetailList
            .GroupBy(detail => detail.SanPham_62132473.LoaiSP)
            .Select(group => new ProductRevenueViewModel
            {
                ProductType = group.Key,
                TypeName = cateBus.GetLoaiSP_62132473ById(group.Key).TenLoaiSP,
                TotalRevenue = group.Sum(detail => detail.DonGia * detail.SoLuong)
            })
            .ToList();

            // Tính toán doanh thu theo người mua hàng đầu
            var revenueByUser = busBill.GetAllRevenue();
            var customerTotalRevenue = revenueByUser
                .Where(item => item?.MaKH != null)
                .GroupBy(item => (int)item.MaKH)
                .ToDictionary(
                    group => group.Key,
                    group => new
                    {
                        CustomerName = customerBus.GetCustomerById(group.Key)?.HoTen ?? "Unknown",
                        TotalRevenue = group.Sum(detail => detail.TongTien)
                    }
                );

            var top5Customers = customerTotalRevenue
                .OrderByDescending(entry => entry.Value.TotalRevenue)
                .Take(5)
                .ToList();

            var resultArray = top5Customers
                .Select(pair => new ProductRevenueViewModel
                {
                    ProductType = pair.Key,
                    TypeName = pair.Value.CustomerName,
                    TotalRevenue = pair.Value.TotalRevenue
                })
                .ToArray();


            ViewBag.revenueByUser = resultArray;
            ViewBag.revenueByType = groupedByType;
            return View();

        }
    }
}