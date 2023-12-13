using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;

namespace PhoneShop.DAO
{
    public class SanPhamDAO
    {
        private PhoneContext context;
        public SanPhamDAO()
        {
            context = new PhoneContext();
        }
        public List<SanPham_62132473> GetSanPham_62132473()
        {
            List<SanPham_62132473> SanPham_62132473 = context.SanPham_62132473.ToList();
            return SanPham_62132473;
        }
        
        public List<SanPham_62132473> GetSanPham_62132473ByLoaiSP(int ID)
        {
            var query = context.SanPham_62132473.AsQueryable();
            List<SanPham_62132473> SanPham_62132473 = query.Where(p => p.LoaiSP == ID).ToList();

            return SanPham_62132473;
        }
        public SanPham_62132473 ViewDetail(int id)
        {
            return context.SanPham_62132473.Find(id);
        }
        public List<SanPham_62132473> GetSanPham_62132473(string keyword)
        {
            List<SanPham_62132473> SanPham_62132473 = context.SanPham_62132473.Where(p => p.TenSP.Contains(keyword)).ToList();
            return SanPham_62132473;
        }
        public void DeleteSanPham_62132473(int id)
        {
            SanPham_62132473 SanPham_62132473 = context.SanPham_62132473.Find(id);

            if (SanPham_62132473 != null)
            {
                // Kiểm tra xem sản phẩm có liên kết với bất kỳ hóa đơn nào không
                if (!context.ChiTietGH_62132473.Any(oi => oi.MaSP == id))
                {
                    context.SanPham_62132473.Remove(SanPham_62132473);
                    context.SaveChanges();
                }
                else
                {

                    SanPham_62132473.xoa = 1;
                    context.SaveChanges();
                }
            }
        }
        public List<SanPham_62132473> GetSanPham_62132473(Dictionary<string, string> queryParams)
        {
            var SanPham_62132473 = context.SanPham_62132473.AsQueryable();

            if (queryParams.ContainsKey("kw"))
            {
                string keyword = queryParams["kw"];
                SanPham_62132473 = SanPham_62132473.Where(p => p.TenSP.Contains(keyword));
            }
            if (queryParams.ContainsKey("categoryId") && queryParams["categoryId"] != null)
            {
                int categoryId = int.Parse(queryParams["categoryId"]);
                SanPham_62132473 = SanPham_62132473.Where(p => p.LoaiSP == (int) categoryId);
            }

            return SanPham_62132473.ToList();
        }
        public void Create(SanPham_62132473 SanPham_62132473)
        {
            try
            {
                context.SanPham_62132473.Add(SanPham_62132473);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the validation errors
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the error messages together
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Throw a new exception with the full error message
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        public bool UpdateInfo(SanPham_62132473 SanPham_62132473, string TenSP, string DonGia, int SLTonKho, string LoaiSP, string Mota,string AnhSP)
        {
            try
            {
                SanPham_62132473.TenSP = TenSP;
                SanPham_62132473.DonGia = float.Parse(DonGia);
                SanPham_62132473.LoaiSP = int.Parse(LoaiSP);
                SanPham_62132473.SLTonKho = SLTonKho;
                SanPham_62132473.Mota = Mota;
                SanPham_62132473.AnhSP = AnhSP;
                context.Entry(SanPham_62132473).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(SanPham_62132473 SanPham_62132473)
        {
            try
            {
                context.Entry(SanPham_62132473).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SanPham_62132473 GetSanPham_62132473ById(int id)
        {
            return context.SanPham_62132473.Find(id);
        }
        public SanPham_62132473 AddSanPham_62132473(SanPham_62132473 SanPham_62132473)
        {
            try
            {
                context.SanPham_62132473.Add(SanPham_62132473);
                context.SaveChanges();
                return SanPham_62132473;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
