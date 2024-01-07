using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.BUS;
using HotelManager.DTO;
namespace HotelManager.Areas.Admin.Controllers
{
    public class CustomerController : Controller
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
            return Json(new { redirectToUrl = Url.Action("Index", "Customer") });
        }
    }
}