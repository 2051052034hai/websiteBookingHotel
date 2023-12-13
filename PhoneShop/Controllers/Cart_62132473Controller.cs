using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.DTO;
using PhoneShop.BUS;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using PhoneShop.Filter;

namespace PhoneShop.Controllers
{
    [CommonAttributeFilter]
    public class Cart_62132473Controller: Controller
    {
        private List<ChiTietGH_62132473> countQuality
        {
            get
            {
                var countQuality = Session["countQuality"] as List<ChiTietGH_62132473>;
                if (countQuality == null)
                {
                    countQuality = new List<ChiTietGH_62132473>();
                    Session["countQuality"] = countQuality;
                }
                return countQuality;
            }
            set
            {
                Session["countQuality"] = value;
            }
        }
        private List<ChiTietGH_62132473> Cart
        {
            get
            {
                var cart = Session["Cart"] as List<ChiTietGH_62132473>;
                if (cart == null)
                {
                    cart = new List<ChiTietGH_62132473>();
                    Session["Cart"] = cart;
                }
                return cart;
            }
            set
            {
                Session["Cart"] = value;
            }
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = this.Cart;

            ViewBag.Cart = cart;

            return View();
        }
        /* -------phương thức đếm số lượng sản phẩm trong giỏ--------------*/
        public ActionResult Count()
        {
            var cart = this.Cart;
            var cartCount = cart.Sum(BD => BD.SoLuong);

            return Json(new { cartCount }, JsonRequestBehavior.AllowGet);
        }

        /* -------phương thức khi thêm sản phẩm vào trong giỏ--------------*/
        [HttpPost]
        public ActionResult AddCart()
        {

            var cart = this.Cart;

            using (var reader = new StreamReader(Request.GetBufferlessInputStream()))
            {
                var body = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<dynamic>(body);

                var countQuality = this.countQuality;

                int productId = data.productId;
                int productQuality = data.productQuality;
                float productPrice = data.productPrice;

                var existingChiTietGH_62132473 = cart.FirstOrDefault(BD => BD.MaSP == productId);

                if (existingChiTietGH_62132473 != null)
                {
                    // Lấy ra đúng sản phẩm đã mua theo ID
                    var existingCountDetail = countQuality.FirstOrDefault(BD => BD.ID == productId);

                    // Kiểm tra sản phẩm này đã được đặt chưa
                    if (existingCountDetail != null)
                    {
                        //cộng dồn số lần người dùng thêm sản phẩm
                        existingCountDetail.SoLuong += productQuality;

                        // Kiểm tra số lượng mua với unitstock của sản phẩm
                        if (existingCountDetail.SoLuong <= existingChiTietGH_62132473.SanPham_62132473.SLTonKho)
                        {
                            // Nếu sản phẩm đã tồn tại, cập nhật trường quality của sản phẩm đó
                            existingChiTietGH_62132473.SoLuong += productQuality;
                        }
                        else
                        {
                            existingCountDetail.SoLuong = existingChiTietGH_62132473.SoLuong;
                            ViewBag.FailMsg = "Bạn không được mua quá lượng tồn kho của sản phẩm";
                            return RedirectToAction("Product", "Product", new { id = productId });

                        }

                    }

                }
                else
                {
                    SanPhamBUS bus = new SanPhamBUS();
                    SanPham_62132473 p = new SanPham_62132473();
                    p = bus.GetSanPham_62132473(productId);

                    ChiTietGH_62132473 newChiTietGH_62132473 = new ChiTietGH_62132473(productQuality, productPrice, productId, p);

                    ChiTietGH_62132473 newQuality = new ChiTietGH_62132473(productId, productQuality);


                    cart.Add(newChiTietGH_62132473);
                    countQuality.Add(newQuality);
                }
                Session["countQuality"] = countQuality;
                Session["Cart"] = cart;
            }

            return View();
        }

        /* -------phương thức khi thanh toán sản phẩm trong giỏ--------------*/
        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Checkout()
        {

            //khai báo
            GioHangBUS billBUS = new GioHangBUS();
            SanPhamBUS SanPhamBUS = new SanPhamBUS();

            // Lấy giỏ hàng từ Session
            var cart = this.Cart;
            DateTime DateNow = DateTime.Now;

            // Tính tổng số tiền cần thanh toán
            float total = 0;
            foreach (var item in cart)
            {
                total += (float)item.DonGia * (float)item.SoLuong;
            }

            if (Session["currentUser"] is KhachHang_62132473)
            {
                var currentUser = Session["currentUser"] as KhachHang_62132473;
                // Lưu thông tin vào cơ sở dữ liệu
                if (currentUser != null)
                {
                    GioHang_62132473 bill = new GioHang_62132473() { NgayDatHang = DateTime.Now, TongTien = total,TinhTrang = 0, MaKH = currentUser.MaKH, isNhanVien = 0};
                    billBUS.Create(bill, cart);

                }
            }
            else
            {
                var currentUser = Session["currentUser"] as NhanVien_62132473;
                // Lưu thông tin vào cơ sở dữ liệu
                if (currentUser != null)
                {
                    GioHang_62132473 bill = new GioHang_62132473() { NgayDatHang = DateTime.Now, TongTien = total,TinhTrang = 0,MaKH_2 = currentUser.MaNV, isNhanVien = 1};
                    billBUS.Create(bill, cart);

                }
            }

            // Xóa giỏ hàng khỏi Session
            Session.Remove("Cart");
            return View();
        }

        /* -------phương thức khi xoá sản phẩm trong giỏ------------*/
        public ActionResult DeleteCart(int MaSP)
        {
            var cart = this.Cart;
            var existingChiTietGH_62132473 = cart.FirstOrDefault(BD => BD.MaSP == MaSP);

            if (existingChiTietGH_62132473 != null)
            {
                // Nếu sản phẩm đã tồn tại trong giỏ hàng, tiến hành xóa
                cart.Remove(existingChiTietGH_62132473);
                Session["Cart"] = cart; // Lưu giỏ hàng mới vào session
            }

            return RedirectToAction("Index");
        }

        /* -------phương thức update sản phẩm trong giỏ------------*/

        [HttpPost]
        public ActionResult UpdateCart()
        {
            var cart = this.Cart;

            using (var reader = new StreamReader(Request.GetBufferlessInputStream()))
            {
                var body = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<dynamic>(body);

                ChiTietGH_62132473[] cartItems = JsonConvert.DeserializeObject<ChiTietGH_62132473[]>(data.cartItems.ToString());

                foreach (var item in cartItems)
                {
                    var existingChiTietGH_62132473 = cart.FirstOrDefault(BD => BD.MaSP == item.MaSP);
                    if (existingChiTietGH_62132473 != null)
                    {
                        existingChiTietGH_62132473.SoLuong = item.SoLuong;
                    }

                }
                Session["Cart"] = cart;
            }

            return RedirectToAction("Index");
        }

    }
}