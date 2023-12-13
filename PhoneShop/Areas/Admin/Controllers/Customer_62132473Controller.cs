using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.BUS;
using PhoneShop.DTO;
namespace PhoneShop.Areas.Admin.Controllers
{
    public class Customer_62132473Controller : Controller
    {
        //GET: Admin/Customer
        public ActionResult Index()
        {
            KhachHangBUS customerBUS = new KhachHangBUS();
            ViewBag.Customers = customerBUS.GetCustomers();
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int customerId)
        {
            KhachHangBUS customerBUS = new KhachHangBUS();
            if (customerBUS.Delete(customerId) > 0)
            {
                TempData["SuccessMsg"] = "Xóa khách hàng thành công!!!";
            }
            return Json(new { redirectToUrl = Url.Action("Index", "Customer_62132473") });
        }
    }
}