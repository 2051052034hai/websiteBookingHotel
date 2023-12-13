using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.BUS;
using PhoneShop.DTO;
using PhoneShop.Filter;

namespace PhoneShop.Areas.Admin.Controllers
{
    public class Product_62132473Controller : Controller
    {
        //GET: Areas/ProductsList
        public ActionResult Index()
        {
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            GioHangBUS billBus = new GioHangBUS();
            List<GioHang_62132473> listbill = billBus.GetAll().OrderByDescending(x => x.SoHD).ToList();
            ViewBag.ListBill = listbill;
            SanPhamBUS bus = new SanPhamBUS();
            var products = bus.GetSanPham_62132473().Where(p => p.xoa == 0).ToList();
            ViewBag.Products = products;
            return View();
        }


        [CommonAttributeFilter]
        public ActionResult Edit(int id)
        {
            SanPhamBUS bus = new SanPhamBUS();
            SanPham_62132473 prod = bus.GetSanPham_62132473(id);
            LoaiSPBUS cateBus = new LoaiSPBUS();
            ViewBag.Categories = cateBus.GetLoaiSP();
            ViewBag.Product = prod;
            return View();
        }
        [HttpPost]
        public ActionResult EditProduct()
        {
            string MaSP = Request.Form["ID"];
            string TenSP = Request.Form["Name"];
            string DonGia = Request.Form["UnitPrice"];
            int SLTonKho = int.Parse( Request.Form["UnitInStock"]);
            string LoaiSP = Request.Form["CateID"];
            string MoTa = Request.Form["Description"];   
            string AnhSP = Request.Form["Image_Url"];
            SanPhamBUS productBUS = new SanPhamBUS();
            productBUS.UpdateSanPham_62132473Info(MaSP, TenSP, DonGia, SLTonKho, LoaiSP, MoTa, AnhSP);

            return RedirectToAction("Index", "Product_62132473");
        }
        public ActionResult Delete(int id)
        {
            SanPhamBUS productBUS = new SanPhamBUS();
            productBUS.Delete(id);
            TempData["SuccessMsg"] = "Xoá sản phẩm thành công";
            return RedirectToAction("Index", "Product_62132473");
        }
        [CommonAttributeFilter]
        public ActionResult Add()
        {
            LoaiSPBUS cateBus = new LoaiSPBUS();
            ViewBag.Categories = cateBus.GetLoaiSP();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct()
        {
           
            string TenSP = Request.Form["Name"];
            float DonGia = float.Parse(Request.Form["UnitPrice"]);
            int SLTonKho = int.Parse(Request.Form["UnitInStock"]);
            int LoaiSP = int.Parse(Request.Form["CateID"]);
            string MoTa = Request.Form["Description"];
            string AnhSP = Request.Form["Image_Url"];
            SanPham_62132473 prod = new SanPham_62132473() { TenSP = TenSP, DonGia = DonGia, 
                SLTonKho = SLTonKho, LoaiSP = LoaiSP, Mota = MoTa, AnhSP = AnhSP};
            SanPhamBUS productBUS = new SanPhamBUS();
            productBUS.Add(prod);
            return RedirectToAction("Index", "Product_62132473");
        }
    }
}