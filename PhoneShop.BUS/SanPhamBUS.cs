using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;
using PhoneShop.DAO;
using System.Data.Entity.Core.Mapping;

namespace PhoneShop.BUS
{
    public class SanPhamBUS
    {
        private readonly SanPhamDAO SanPhamDAO;
        public SanPhamBUS()
        {
           SanPhamDAO = new SanPhamDAO();
        }
        public List<SanPham_62132473> GetSanPham_62132473()
        {
            SanPhamDAO SanPhamDAO = new SanPhamDAO();
            return SanPhamDAO.GetSanPham_62132473();
        }
        public SanPham_62132473 Add(SanPham_62132473 SanPham_62132473)
        {
            return SanPhamDAO.AddSanPham_62132473(SanPham_62132473);
        }
        public void Delete(int id )
        {
            SanPhamDAO.DeleteSanPham_62132473(id);
        }
        public List<SanPham_62132473> GetSanPham_62132473(string kw)
        {
            SanPhamDAO SanPhamDAO = new SanPhamDAO();
            return SanPhamDAO.GetSanPham_62132473(kw);
        }
       
        public List<SanPham_62132473> GetSanPham_62132473(Dictionary<string, string> queryParams)
        {
            SanPhamDAO SanPhamDAO = new SanPhamDAO();
            return SanPhamDAO.GetSanPham_62132473(queryParams);
        }

        public object GetSanPham_62132473(int? SanPham_62132473ID)
        {
            throw new NotImplementedException();
        }
        public List<SanPham_62132473> GetSanPham_62132473ByCateID(int cateID)
        {
            return SanPhamDAO.GetSanPham_62132473ByLoaiSP(cateID);
        }
        public bool UpdateSanPham_62132473Info(string id, string TenSP, string DonGia, int SLTonKho, string LoaiSP, string Mota, string AnhSP)
        {
            try
            {
                SanPham_62132473 SanPham_62132473=SanPhamDAO.GetSanPham_62132473ById(int.Parse(id));
                return SanPhamDAO.UpdateInfo(SanPham_62132473, TenSP, DonGia, SLTonKho, LoaiSP, Mota, AnhSP);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SanPham_62132473 GetSanPham_62132473(int id)
        {
            SanPhamDAO SanPhamDAO = new SanPhamDAO();
            return SanPhamDAO.GetSanPham_62132473ById(id);
        }
    }
}
