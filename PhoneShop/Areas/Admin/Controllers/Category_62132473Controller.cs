using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PhoneShop.BUS;
using PhoneShop.DTO;
using PhoneShop.Filter;
namespace PhoneShop.Areas.Admin.Controllers
{
    public class Category_62132473Controller : Controller
    {
        [CommonAttributeFilter]
        // GET: Admin/Category
        public ActionResult Index()
        {
            LoaiSPBUS cate = new LoaiSPBUS();
            List<LoaiSP_62132473> Categories = cate.GetLoaiSP();
            ViewBag.Categories = Categories;
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View();
        }
        public ActionResult Edit(int id)
        {
            LoaiSPBUS bus = new LoaiSPBUS();
            LoaiSP_62132473 cate = bus.GetLoaiSP_62132473ById(id);
            ViewBag.Cate = cate;
            return View(cate);
        }
        [HttpPost]
        public ActionResult EditCategory()
        {
            string ID = Request.Form["ID"];
            string Name = Request.Form["Name"];
            LoaiSPBUS categoryBUS = new LoaiSPBUS();
            LoaiSP_62132473 cate = categoryBUS.GetLoaiSP_62132473ById(Int32.Parse(ID));
            if (categoryBUS.UpdateInfo(cate, Name))
                TempData["SuccessMsg"] = "Cập nhật thành công";

            return RedirectToAction("Index", "Category_62132473");
        }
        public ActionResult Delete(int id)
        {
            LoaiSPBUS categoryBUS = new LoaiSPBUS();
            categoryBUS.DeleteLoaiSP_62132473(id);
            TempData["SuccessMsg"] = "Xoá loại sản phẩm thành công";
            return RedirectToAction("Index", "Category_62132473");
        }

        [HttpPost]
        public ActionResult AddCategory()
        {
            string Name = Request.Form["Name"];
            LoaiSP_62132473 cate = new LoaiSP_62132473() { TenLoaiSP = Name };
            LoaiSPBUS categoryBUS = new LoaiSPBUS();
            categoryBUS.AddLoaiSP_62132473(cate);
            return RedirectToAction("Index", "Category_62132473");
        }
    }
}