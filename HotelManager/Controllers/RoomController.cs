using HotelManager.BUS;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Filter;

namespace HotelManager.Controllers
{
    [CommonAttributeFilter]
    public class RoomController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Room(int id)
        {
            RoomBUS bus = new RoomBUS();
            ServiceBUS serviceBUS = new ServiceBUS();

            Room p = bus.GetRoom(id);
            List<Room> Rooms = bus.GetRoomByCateID(p.typeRoom);
            List<Service> Services = new List<Service>();
            Services = serviceBUS.GetService();

            ViewBag.Phong = p;
            ViewBag.PhongByLoaiPhong = Rooms;
            ViewBag.Services = Services;

            return View();
        }

    }
}