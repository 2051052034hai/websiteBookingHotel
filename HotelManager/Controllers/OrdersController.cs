 using HotelManager.BUS;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using HotelManager.Filter;
using System.IO;
using System.Data.Entity;

namespace HotelManager.Controllers
{
    public class OrdersController : Controller
    {
        [CommonAttributeFilter]
        public ActionResult Index(int id)
        {
            OrdersBUS bus = new OrdersBUS();
            List<Order> orders = new List<Order>();
            orders = bus.GetOrdersByCustomerID(id);
            ViewBag.orders = orders;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteOrder(int orderID)
        {
            OrdersBUS bus = new OrdersBUS();
            RoomBUS roomBus = new RoomBUS();

            Order order = bus.GetOrderByID(orderID);
            Room room = roomBus.GetRoom(order.roomID);

            bus.UpdateStatus(order,1);

            if (room != null)
            {
                roomBus.UpdateStatus(room, 0);
            }

            return RedirectToAction("Index", "Orders", new { id = orderID });
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
         
            using (var reader = new StreamReader(Request.GetBufferlessInputStream()))
            {
                var body = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Order>(body);

                //Lấy phòng theo orderID 
                RoomBUS roomBus = new RoomBUS();
                Room room = roomBus.GetRoom(data.roomID);

                using (var dbContext = new HotelManagerContext())
                {
                    dbContext.Orders.Add(data);
                    dbContext.SaveChanges();

                    if (room != null)
                    {
                        roomBus.UpdateStatus(room, 1);
                    }
                }

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Order newData)
        {
            try
            {
                OrdersBUS order = new OrdersBUS();
                order.UpdateAdmin(newData);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

    }
}