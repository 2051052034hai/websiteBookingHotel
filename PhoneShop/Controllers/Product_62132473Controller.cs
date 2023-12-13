using PhoneShop.BUS;
using PhoneShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.Filter;

namespace PhoneShop.Controllers
{
    [CommonAttributeFilter]
    public class Product_62132473Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPham(int id)
        {
            SanPhamBUS bus = new SanPhamBUS();

            SanPham_62132473 p = bus.GetSanPham_62132473(id);
            List<SanPham_62132473> SanPham_62132473s = bus.GetSanPham_62132473ByCateID(p.LoaiSP);

            ViewBag.SanPham = p;
            ViewBag.SanPhamByLoaiSP = SanPham_62132473s;

            return View();
        }

    }
}