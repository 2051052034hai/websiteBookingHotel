using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.BUS;
using HotelManager.DTO;
using HotelManager.Filter;

namespace HotelManager.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Admin/Orders
        public ActionResult Index()
        {
            OrdersBUS ordersBUS = new OrdersBUS();
            List<Order> orders = ordersBUS.GetOrders();
            ViewBag.orders = orders;
            return View();
        }

    }
}