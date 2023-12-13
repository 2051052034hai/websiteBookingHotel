using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DAO;
using PhoneShop.DTO;

namespace PhoneShop.BUS
{
    public class LoaiSPBUS
    {
        private LoaiSPDAO LoaiSPDAO;

        public LoaiSPBUS()
        {
            LoaiSPDAO = new LoaiSPDAO(); // Khởi tạo đối tượng LoaiSPDAO để truy xuất dữ liệu từ bảng Categories
        }

        // Phương thức lấy danh sách các mục danh mục từ bảng Categories
        public List<LoaiSP_62132473> GetLoaiSP()
        {
            return LoaiSPDAO.GetLoaiSP_62132473();
        }

        // Phương thức lấy một mục danh mục từ bảng Categories theo ID
        public LoaiSP_62132473 GetLoaiSP_62132473ById(int LoaiSP_62132473Id)
        {
            return LoaiSPDAO.GetLoaiSP_62132473ById(LoaiSP_62132473Id);
        }

        // Phương thức thêm một mục danh mục vào bảng Categories
        public void AddLoaiSP_62132473(LoaiSP_62132473 LoaiSP_62132473)
        {
            LoaiSPDAO.AddLoaiSP_62132473(LoaiSP_62132473);
        }

        // Phương thức sửa một mục danh mục trong bảng Categories
        public void UpdateLoaiSP_62132473(LoaiSP_62132473 LoaiSP_62132473)
        {
            LoaiSPDAO.UpdateLoaiSP_62132473(LoaiSP_62132473);
        }

        // Phương thức xoá một mục danh mục khỏi bảng Categories
        public bool DeleteLoaiSP_62132473(int LoaiSP_62132473Id)
        {
            if (LoaiSPDAO.DeleteLoaiSP_62132473(LoaiSP_62132473Id))
                return true;
            else
                return false;
        }
        public bool UpdateInfo(LoaiSP_62132473 LoaiSP_62132473, string name)
        {
            try
            {
                // Gọi phương thức UpdateInfo() trên đối tượng repository
                LoaiSPDAO.UpdateInfo(LoaiSP_62132473, name);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
