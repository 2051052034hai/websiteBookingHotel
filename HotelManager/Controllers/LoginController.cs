using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.DTO;
using HotelManager.BUS;
using System.Web.Helpers;
using HotelManager.Filter;
using HotelManager.Utils;


namespace HotelManager.Controllers
{
    [CommonAttributeFilter]
    public class LoginController : Controller
    {
        // GET: Login
        [AnonymousFilter]
        public ActionResult Index()
        {
            ViewBag.FailMsg = TempData["FailMsg"] as string;
            ViewBag.Username = TempData["username"] as string;
            return View();
        }

        [AnonymousFilter]
        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AnonymousFilter]
        public ActionResult Login(string email, string password)
        {

                KhachHangBUS customerBUS = new KhachHangBUS();
                Customer customer = customerBUS.Authenticate(email, Utils.Utils.GetMD5(password));
                if (customer != null)
                {
                    Session["currentUser"] = customer;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["FailMsg"] = "Đăng nhập thất bại!!! Email hoặc password không khớp";
                    TempData["email"] = email;
                    return RedirectToAction("Index", "Login");
                }
        }

        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Remove("currentUser");
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ViewResult Register()
        {
            ViewBag.FailMsg = TempData["FailMsg"] as string;
            return View();
        }


        [HttpPost]
        [AnonymousFilter]
        public ActionResult AddCustomer()
        {
            // Dữ liệu nhận được từ client fetch lên
            string HoTen = Request.Form["username"];
            string DiaChi = Request.Form["address"];
            string SDT = Request.Form["phone"];
            string MatKhau = Request.Form["password"];
            string Email = Request.Form["email"];
            int DeleteFlg = 0;
            int RoleID = 1;

                Customer cus = new Customer(HoTen, DiaChi, SDT, Utils.Utils.GetMD5(MatKhau), Email, DeleteFlg, RoleID);
                KhachHangBUS customerBUS = new KhachHangBUS();
                if (customerBUS.Create(cus) > 0)
                    return RedirectToAction("Index", "Login");
                else
                {
                    TempData["FailMsg"] = "Đăng ký không thành công!!! Tài khoản đã có trong hệ thống";
                    return RedirectToAction("Register", "Login");
                }
            }
        }
    }
