using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;
using PhoneShop.DAO;

namespace PhoneShop.BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO KhachHangDAO;
        public KhachHangBUS()
        {
            KhachHangDAO = new KhachHangDAO();
        }

        public KhachHang_62132473 GetCustomerById(int MaKH)
        {
            return KhachHangDAO.GetCustomerById(MaKH);
        }

        public List<KhachHang_62132473> GetCustomers()
        {
            return KhachHangDAO.GetAllCustomers();
        }

        public int Create(KhachHang_62132473 customer)
        {
            if (KhachHangDAO.GetByUserEmail(customer.Email) != null)
                return 0;
            return KhachHangDAO.Create(customer);
        }
        public int Update(string MaKH, string HoTen, string SDT, string DiaChi, string MatKhau)
        {
            KhachHangDAO customerDAO = new KhachHangDAO();
            KhachHang_62132473 customer = customerDAO.GetCustomerById(int.Parse(MaKH));
            customer.HoTen = HoTen;
            customer.SDT = SDT;
            customer.DiaChi = DiaChi;
            customer.MatKhau = MatKhau;

            if (customerDAO.Update(customer) > 0)
                return 1;
            return 0;
        }
        public int Update(string MaKH, string MatKhau, string MatKhauMoi)
        {
            KhachHangDAO customerDAO = new KhachHangDAO();
            KhachHang_62132473 customer = customerDAO.GetCustomerById(int.Parse(MaKH));
            if (!customer.MatKhau.Equals(MatKhau))
            {
                return 0;
            }
            customer.MatKhau = MatKhauMoi;
            if (customerDAO.Update(customer) > 0)
                return 1;
            return 0;
        }

        public int Update(int MaKH)
        {
            KhachHangDAO customerDAO = new KhachHangDAO();
            KhachHang_62132473 customer = customerDAO.GetCustomerById(MaKH);
            return customerDAO.Update(customer);
        }
        public KhachHang_62132473 Authenticate(string email, string MatKhau)
        {
            KhachHang_62132473 customer = KhachHangDAO.GetByUserEmail(email);
            if (customer == null || !customer.MatKhau.Equals(MatKhau))
                return null;
            return customer;
        }

        public int Delete(int MaKH)
        {
            return KhachHangDAO.Delete(MaKH);
        }
    }
}
