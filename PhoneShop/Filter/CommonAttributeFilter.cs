using PhoneShop.BUS;
using PhoneShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShop.Filter
{
    public class CommonAttributeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        
        {
            LoaiSPBUS loaiSPBUS = new LoaiSPBUS();
            List<LoaiSP_62132473> loaiSP = loaiSPBUS.GetLoaiSP();
            filterContext.Controller.ViewBag.LoaiSP = loaiSP;
            base.OnActionExecuting(filterContext);
        }
    }
}