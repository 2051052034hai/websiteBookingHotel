using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneShop.DTO;
using PhoneShop.BUS;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
using PhoneShop.Filter;

namespace PhoneShop.Controllers
{
    [CommonAttributeFilter]
    public class Home_62132473Controller : Controller
    {
        public ActionResult Index()
        {
            SanPhamBUS SanPhamBUS = new SanPhamBUS();
            List<SanPham_62132473> SanPham_62132473s = SanPhamBUS.GetSanPham_62132473();
            ViewBag.SanPham_62132473s = SanPham_62132473s;

            return View();
        }

        public ActionResult CategoryProduct([Bind(Prefix = "search")] string searchKw, [Bind(Prefix = "LoaiSP")] string LoaiSP)
        {
            SanPhamBUS SanPhamBUS = new SanPhamBUS();
            LoaiSPBUS LoaiSPBUS = new LoaiSPBUS();
            LoaiSP_62132473 cate = new LoaiSP_62132473();
            List<SanPham_62132473> SanPham_62132473s = null;
            List<SanPham_62132473> SanPham_resultSearch = null;

            if (!searchKw.IsNullOrWhiteSpace())
            {
                SanPham_62132473s = SanPhamBUS.GetSanPham_62132473(searchKw);
                SanPham_resultSearch = SanPham_62132473s;
            }
            else
                SanPham_62132473s = SanPhamBUS.GetSanPham_62132473();

            if (LoaiSP != null)
            {
                List<SanPham_62132473> SanPham_62132473s1 = (List<SanPham_62132473>)SanPham_62132473s.Where(p => p.LoaiSP == int.Parse(LoaiSP)).ToList();
                SanPham_62132473s = SanPham_62132473s1;
            }
            if(SanPham_resultSearch != null)
            {
                if (LoaiSP == null && SanPham_resultSearch.Count == 0)
                {
                    SanPham_62132473s = null;
                }
            }else if(LoaiSP == null)
            {
                SanPham_resultSearch = SanPham_62132473s;
            }
            
            ViewBag.SanPham_62132473s = SanPham_62132473s;
           
            return View();
        }

        public ActionResult LoaiSP(string id)
        {
            SanPhamBUS SanPhamBUS = new SanPhamBUS();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("LoaiSP", id);
            List<SanPham_62132473> SanPham_62132473s = SanPhamBUS.GetSanPham_62132473(queryParams);
            ViewBag.SanPham_62132473s = SanPham_62132473s;
            return View();
        }
    }
}
