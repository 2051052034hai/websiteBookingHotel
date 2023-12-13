using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.DTO;
using PhoneShop.BUS;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using PhoneShop.Filter;
namespace PhoneShop.Controllers
{
    public class Bill_62132473Controller : Controller
    {
        // GET: Bill_62132473
        public ActionResult Index()
        {
            GioHangBUS bill = new GioHangBUS();
            List<GioHang_62132473> carts = bill.GetAll();
            NhanVienBUS cus = new NhanVienBUS();
            List<NhanVien_62132473> customers = cus.GetemployeesStaff();
            ViewBag.customers = customers;
            ViewBag.carts = carts;
            return View();
        }

        [HttpPost]
        public ActionResult Update(GioHang_62132473 newData)
        {
            try
            {
                GioHangBUS bill = new GioHangBUS();
                bill.Update(newData); 
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult UpdateAdmin(GioHang_62132473 newData)
        {
            try
            {
                GioHangBUS bill = new GioHangBUS();
                bill.UpdateAdmin(newData);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}