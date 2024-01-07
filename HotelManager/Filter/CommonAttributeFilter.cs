using HotelManager.BUS;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Filter
{
    public class CommonAttributeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        
        {
            TypeRoomBUS TypeRoomBUS = new TypeRoomBUS();
            List<TypeRoom> loaiPhong = TypeRoomBUS.GetTypeRoom();
            filterContext.Controller.ViewBag.loaiPhong = loaiPhong;
            base.OnActionExecuting(filterContext);
        }
    }
}