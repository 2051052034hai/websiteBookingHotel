using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.DTO;
using HotelManager.BUS;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
using HotelManager.Filter;

namespace HotelManager.Controllers
{
    [CommonAttributeFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RoomBUS RoomBUS = new RoomBUS();
            TypeRoomBUS typeRoomBUS = new TypeRoomBUS();

            List<Room> Rooms = RoomBUS.GetRoomHome();
            List<TypeRoom> typeRooms = typeRoomBUS.GetTypeRoom();

            ViewBag.Rooms = Rooms;
            ViewBag.typeRooms = typeRooms;

            return View();
        }

        public ActionResult RoomInType([Bind(Prefix = "search")] string searchKw, [Bind(Prefix = "LoaiPhong")] string LoaiPhong)
        {
            RoomBUS RoomBUS = new RoomBUS();
            TypeRoomBUS TypeRoomBUS = new TypeRoomBUS();
            TypeRoom cate = new TypeRoom();
            List<Room> Rooms = null;
            List<Room> SanPham_resultSearch = null;

            if (!searchKw.IsNullOrWhiteSpace())
            {
                Rooms = RoomBUS.GetRoom(searchKw);
                SanPham_resultSearch = Rooms;
            }
            else
                Rooms = RoomBUS.GetRoom();

            if (LoaiPhong != null)
            {
                List<Room> Rooms1 = (List<Room>)Rooms.Where(p => p.typeRoom == int.Parse(LoaiPhong)).ToList();
                Rooms = Rooms1;
            }
            if(SanPham_resultSearch != null)
            {
                if (LoaiPhong == null && SanPham_resultSearch.Count == 0)
                {
                    Rooms = null;
                }
            }else if(LoaiPhong == null)
            {
                SanPham_resultSearch = Rooms;
            }
            
            ViewBag.Rooms = Rooms;
           
            return View();
        }

        public ActionResult TypeRoom(string id)
        {
            RoomBUS RoomBUS = new RoomBUS();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("TypeRoom", id);
            List<Room> Rooms = RoomBUS.GetRoom(queryParams);
            ViewBag.Rooms = Rooms;
            return View();
        }
    }
}
