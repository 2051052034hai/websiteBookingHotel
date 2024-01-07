using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HotelManager.BUS;
using HotelManager.DTO;
using HotelManager.Filter;
namespace HotelManager.Areas.Admin.Controllers
{
    public class TypeRoomController : Controller
    {
        [CommonAttributeFilter]
        // GET: Admin/Category
        public ActionResult Index()
        {
            TypeRoomBUS typeRoom = new TypeRoomBUS();
            List<TypeRoom> typeRooms = typeRoom.GetTypeRoom();
            ViewBag.typeRooms = typeRooms;
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View();
        }
        public ActionResult Edit(int id)
        {
            TypeRoomBUS bus = new TypeRoomBUS();
            TypeRoom typeRoom = bus.GetTypeRoomById(id);
            ViewBag.typeRoom = typeRoom;
            return View(typeRoom);
        }
        [HttpPost]
        public ActionResult EditTypeRoom()
        {
            string ID = Request.Form["ID"];
            string Name = Request.Form["Name"];
            TypeRoomBUS categoryBUS = new TypeRoomBUS();
            TypeRoom cate = categoryBUS.GetTypeRoomById(Int32.Parse(ID));
            if (categoryBUS.UpdateInfo(cate, Name))
                TempData["SuccessMsg"] = "Cập nhật thành công";

            return RedirectToAction("Index", "TypeRoom");
        }
        public ActionResult Delete(int id)
        {
            TypeRoomBUS typeRoomBUS = new TypeRoomBUS();
            typeRoomBUS.DeleteTypeRoom(id);
            TempData["SuccessMsg"] = "Xoá loại phòng thành công";
            return RedirectToAction("Index", "TypeRoom");
        }

        [HttpPost]
        public ActionResult AddTypeRoom()
        {
            string Name = Request.Form["Name"];
            TypeRoom typeRoom = new TypeRoom() { name = Name };
            TypeRoomBUS typeRoomBUS = new TypeRoomBUS();
            typeRoomBUS.AddTypeRoom(typeRoom);
            return RedirectToAction("Index", "TypeRoom");
        }
    }
}