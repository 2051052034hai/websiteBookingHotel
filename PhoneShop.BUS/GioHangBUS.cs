using PhoneShop.DAO;
using PhoneShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.BUS
{
    public class GioHangBUS
    {
        private readonly GioHangDAO GioHangDAO;

        public GioHangBUS()
        {
            GioHangDAO = new GioHangDAO();
        }

        public int Create(GioHang_62132473 bill, List<ChiTietGH_62132473> billDetails)
        {
            try
            {
                return GioHangDAO.Create(bill, billDetails);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public GioHang_62132473 GetBillById(int id)
        {
            return GioHangDAO.GetBillById(id);
        }

        public List<GioHang_62132473> GetAll()
        {
            return GioHangDAO.GetAll();
        }

        public List<GioHang_62132473> GetAllAdmin()
        {
            return GioHangDAO.GetAllAdmin();
        }


        public List<GioHang_62132473> GetAllRevenue()
        {
            return GioHangDAO.GetAllRevenue();
        }

        public List<GioHang_62132473> GetBillsByCustomerId(int customerId)
        {
            return GioHangDAO.GetBillsByCustomerId(customerId);
        }

        public int Update(GioHang_62132473 bill)
        {
            try
            {
                GioHangDAO.Update(bill);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateAdmin(GioHang_62132473 bill)
        {
            try
            {
                GioHangDAO.UpdateAdmin(bill);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(GioHang_62132473 bill)
        {
            try
            {
                GioHangDAO.Delete(bill);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}