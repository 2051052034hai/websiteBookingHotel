using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.BUS;
using HotelManager.DTO;
namespace HotelManager.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Admin/Service
        public ActionResult Index()
        {
            ServiceBUS serviceBUS = new ServiceBUS();
            List<Service> services = serviceBUS.GetService();
            ViewBag.services = services;
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View();
        }
        public ActionResult Edit(int id)
        {
            ServiceBUS bus = new ServiceBUS();
            Service service = bus.GetserviceById(id);
            ViewBag.service = service;
            return View(service);
        }
        [HttpPost]
        public ActionResult EditService()
        {
            string ID = Request.Form["ID"];
            string Name = Request.Form["Name"];
            float UnitPrice = float.Parse(Request.Form["UnitPrice"]);
            ServiceBUS serviceBUS = new ServiceBUS();
            Service service = serviceBUS.GetserviceById(Int32.Parse(ID));
            if (serviceBUS.UpdateInfo(service, Name, UnitPrice))
                TempData["SuccessMsg"] = "Cập nhật thành công";

            return RedirectToAction("Index", "Service");
        }
        public ActionResult Delete(int id)
        {
            ServiceBUS ServiceBUS = new ServiceBUS();
            ServiceBUS.DeleteService(id);
            TempData["SuccessMsg"] = "Xoá dịch vụ thành công";
            return RedirectToAction("Index", "Service");
        }

        [HttpPost]
        public ActionResult AddService()
        {
            string Name = Request.Form["Name"];
            float UnitPrice = float.Parse(Request.Form["UnitPrice"]);
            Service service = new Service() { name = Name, unitPrice = UnitPrice };
            ServiceBUS ServiceBUS = new ServiceBUS();
            ServiceBUS.AddService(service);
            return RedirectToAction("Index", "Service");
        }


    }
}