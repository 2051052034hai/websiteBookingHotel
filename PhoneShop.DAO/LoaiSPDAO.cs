using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;

namespace PhoneShop.DAO
{
    public class LoaiSPDAO
    {
        private PhoneContext context;

        public LoaiSPDAO()
        {
            context = new PhoneContext(); // Khởi tạo đối tượng DbContext để truy xuất cơ sở dữ liệu
        }

        // Phương thức lấy danh sách các mục danh mục từ bảng LoaiSP_62132473
        public List<LoaiSP_62132473> GetLoaiSP_62132473()
        {
            return context.LoaiSP_62132473.ToList();
        }

        // Phương thức lấy một mục danh mục từ bảng LoaiSP_62132473 theo ID
        public LoaiSP_62132473 GetLoaiSP_62132473ById(int LoaiSP_62132473Id)
        {
            return context.LoaiSP_62132473.Find(LoaiSP_62132473Id);
        }

        // Phương thức thêm một mục danh mục vào bảng LoaiSP_62132473
        public void AddLoaiSP_62132473(LoaiSP_62132473 LoaiSP)
        {
            context.LoaiSP_62132473.Add(LoaiSP);
            context.SaveChanges();
        }
        public bool UpdateInfo(LoaiSP_62132473 LoaiSP, string TenLoaiSP)
        {
            try
            {
                LoaiSP.TenLoaiSP = TenLoaiSP;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Phương thức sửa một mục danh mục trong bảng LoaiSP_62132473
        public void UpdateLoaiSP_62132473(LoaiSP_62132473 LoaiSP)
        {
            context.Entry(LoaiSP).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Phương thức xoá một mục danh mục khỏi bảng LoaiSP_62132473
        public bool DeleteLoaiSP_62132473(int LoaiSP)
        {
            try
            {
                LoaiSP_62132473 LoaiSP_62132473 = context.LoaiSP_62132473.Find(LoaiSP);
                context.LoaiSP_62132473.Remove(LoaiSP_62132473);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
 
}
}
