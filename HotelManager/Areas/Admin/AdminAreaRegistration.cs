﻿using System.Web.Mvc;

namespace HotelManager.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
            name: "Admin_custom",
            url: "Admin/{controller}/{action}/{id}",
            defaults: new { action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "HotelManager.Areas.Admin.Controllers" }
            );
        }
    }
}