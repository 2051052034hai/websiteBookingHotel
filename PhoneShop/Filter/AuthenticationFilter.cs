using PhoneShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhoneShop.Filter
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = filterContext.HttpContext.Session["currentUser"] as KhachHang_62132473;
            var currentEmployee = filterContext.HttpContext.Session["currentUser"] as NhanVien_62132473;
            if (currentUser == null && currentEmployee == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login_62132473",
                    action = "Index"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}