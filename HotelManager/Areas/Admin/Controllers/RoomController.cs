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
    public class RoomController : Controller
    {
        //GET: Areas/ProductsList
        public ActionResult Index()
        {
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            RoomBUS bus = new RoomBUS();
            TypeRoomBUS typeRoomBUS = new TypeRoomBUS();

            var rooms = bus.GetRoom();
            ViewBag.rooms = rooms;
            ViewBag.typeRoom = typeRoomBUS.GetTypeRoom();
            return View();
        }


        [CommonAttributeFilter]
        public ActionResult Edit(int id)
        {
            RoomBUS bus = new RoomBUS();
            Room Room = bus.GetRoom(id);
            ViewBag.Room = Room;
            return View();
        }
        [HttpPost]
        public ActionResult EditRoom()
        {
            string MaPhong = Request.Form["ID"];
            string TenPhong = Request.Form["Name"];
            float DonGia = float.Parse(Request.Form["UnitPrice"]);
            string MoTa = Request.Form["Description"];
            float giamGia = float.Parse(Request.Form["Discount"]);
            string AnhSP = Request.Form["Image_Url"];
            int SL = int.Parse(Request.Form["Quantity"]);
            int LoaiPhong = int.Parse(Request.Form["TypeRoom"]);
            
            RoomBUS roomBUS = new RoomBUS();
            roomBUS.UpdateRoomInfo(MaPhong, TenPhong, DonGia, MoTa, giamGia, AnhSP, SL, LoaiPhong);

            return RedirectToAction("Index", "Room");
        }
        public ActionResult Delete(int id)
        {
            RoomBUS roomBUS = new RoomBUS();
            roomBUS.Delete(id);
            TempData["SuccessMsg"] = "Xoá phòng thành công";
            return RedirectToAction("Index", "Room");
        }
        [CommonAttributeFilter]
        public ActionResult Add()
        {
            TypeRoomBUS typeRoomBUS = new TypeRoomBUS();
            ViewBag.Categories = typeRoomBUS.GetTypeRoom();
            return View();
        }
        [HttpPost]
        public ActionResult AddRoom()
        {

            string TenPhong = Request.Form["Name"];
            float DonGia = float.Parse(Request.Form["UnitPrice"]);
            int SL = int.Parse(Request.Form["Quantity"]);
            int LoaiPhong = int.Parse(Request.Form["TypeRoom"]);
            float giamGia = float.Parse(Request.Form["Discount"]);
            string MoTa = Request.Form["Description"];
            string AnhSP = Request.Form["Image_Url"];
            int status = 0;
            Room prod = new Room()
            {
                name = TenPhong,
                unitPrice = DonGia,
                quantity = SL,
                typeRoom = LoaiPhong,
                discount = giamGia,
                description = MoTa,
                image = AnhSP,
                status = status
            };
            RoomBUS roomBUS = new RoomBUS();
            roomBUS.Add(prod);
            return RedirectToAction("Index", "Room");
        }
    }
}