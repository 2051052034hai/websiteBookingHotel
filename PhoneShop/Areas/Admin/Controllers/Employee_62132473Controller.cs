using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PhoneShop.BUS;
using PhoneShop.DTO;

namespace PhoneShop.Areas.Admin.Controllers
{
    public class Employee_62132473Controller : Controller
    {
        // GET: Admin/Employee_6213473
        public ActionResult Index()
        {
            NhanVienBUS emp = new NhanVienBUS();
            ViewBag.Employees = emp.Getemployees();
            ViewBag.SuccessEmp = TempData["SuccessEmp"];
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int employeeId)
        {
            NhanVienBUS empBus = new NhanVienBUS();
            if (empBus.Delete(employeeId) > 0)
            {
                TempData["SuccessEmp"] = "Xóa nhân viên thành công!!!";
            }
            return Json(new { redirectToUrl = Url.Action("Index", "Employee_62132473") });
        }
    }
}