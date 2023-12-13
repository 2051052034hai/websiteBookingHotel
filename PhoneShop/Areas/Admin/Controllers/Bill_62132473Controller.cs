using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.BUS;
using PhoneShop.DTO;

namespace PhoneShop.Areas.Admin.Controllers
{
    public class Bill_62132473Controller : Controller
    {
        // GET: Admin/Bill_6213473
        public ActionResult Index()
        {
            GioHangBUS bill = new GioHangBUS();
            ViewBag.bills = bill.GetAllAdmin();
            return View();
        }
    }
}