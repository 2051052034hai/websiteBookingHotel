using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.DTO;
using PhoneShop.BUS;
using System.Web.Helpers;
using PhoneShop.Filter;
using PhoneShop.Utils;


namespace PhoneShop.Controllers
{
    [CommonAttributeFilter]
    public class Login_62132473Controller: Controller
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
            string chucVu = Request.Form["loginType"];
            int QuyenSD = int.Parse(chucVu);

            if(QuyenSD == 1)
            {
                KhachHangBUS customerBUS = new KhachHangBUS();
                KhachHang_62132473 customer = customerBUS.Authenticate(email, Utils.Utils.GetMD5(password));
                if (customer != null)
                {
                    Session["currentUser"] = customer;
                    return RedirectToAction("Index", "Home_62132473");
                }
                else
                {
                    TempData["FailMsg"] = "Đăng nhập thất bại!!! Email hoặc password không khớp";
                    TempData["email"] = email;
                    return RedirectToAction("Index", "Login_62132473");
                }
            }else
            {
                NhanVienBUS employeeBUS = new NhanVienBUS();
                NhanVien_62132473 employee = employeeBUS.Authenticate(email, Utils.Utils.GetMD5(password));
                if (employee != null)
                {
                    Session["currentUser"] = employee;
                    return RedirectToAction("Index", "Home_62132473");
                }
                else
                {
                    TempData["FailMsg"] = "Đăng nhập thất bại!!! Email hoặc password không khớp";
                    TempData["email"] = email;
                    return RedirectToAction("Index", "Login_62132473");
                }
            }
           
  
        }

        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Remove("currentUser");
            return RedirectToAction("Login", "Login_62132473");
        }

        [HttpGet]
        public ViewResult Register()
        {
            RoleBUS role = new RoleBUS();
            List<QuyenSD_62132473> roles = role.GetRole_62132473();
            ViewBag.roles = roles;
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
            string chucVu = Request.Form["loginType"];
            int QuyenSD = int.Parse(chucVu);

            if(QuyenSD == 1)
            {
                KhachHang_62132473 cus = new KhachHang_62132473(HoTen, DiaChi, SDT, Utils.Utils.GetMD5(MatKhau), Email, QuyenSD);
                KhachHangBUS customerBUS = new KhachHangBUS();
                if (customerBUS.Create(cus) > 0)
                    return RedirectToAction("Index", "Login_62132473");
                else
                {
                    TempData["FailMsg"] = "Đăng ký không thành công!!! Tài khoản đã có trong hệ thống";
                    return RedirectToAction("Register", "Login_62132473");
                }
            }else
            {
                NhanVien_62132473 nv = new NhanVien_62132473(HoTen, DiaChi, SDT, Utils.Utils.GetMD5(MatKhau), Email, QuyenSD);
                NhanVienBUS Employeebus = new NhanVienBUS();
                if (Employeebus.Create(nv) > 0)
                {
                    return RedirectToAction("Index", "Login_62132473");
                }else
                {
                    TempData["FailMsg"] = "Đăng ký không thành công!!! Tài khoản đã có trong hệ thống";
                    return RedirectToAction("Register", "Login_62132473");
                }
                   
            }
            
        }
    }
}