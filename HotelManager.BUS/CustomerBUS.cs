using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DTO;
using HotelManager.DAO;

namespace HotelManager.BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO KhachHangDAO;
        public KhachHangBUS()
        {
            KhachHangDAO = new KhachHangDAO();
        }

        public Customer GetCustomerById(int MaKH)
        {
            return KhachHangDAO.GetCustomerById(MaKH);
        }

        public List<Customer> GetCustomers()
        {
            return KhachHangDAO.GetAllCustomers();
        }

        public int Create(Customer customer)
        {
            if (KhachHangDAO.GetByUserEmail(customer.email) != null)
                return 0;
            return KhachHangDAO.Create(customer);
        }
        public int Update(string MaKH, string HoTen, string SDT, string DiaChi, string MatKhau)
        {
            KhachHangDAO customerDAO = new KhachHangDAO();
            Customer customer = customerDAO.GetCustomerById(int.Parse(MaKH));
            customer.name = HoTen;
            customer.phone = SDT;
            customer.address = DiaChi;
            customer.password = MatKhau;

            if (customerDAO.Update(customer) > 0)
                return 1;
            return 0;
        }
        public int Update(string MaKH, string MatKhau, string MatKhauMoi)
        {
            KhachHangDAO customerDAO = new KhachHangDAO();
            Customer customer = customerDAO.GetCustomerById(int.Parse(MaKH));
            if (!customer.password.Equals(MatKhau))
            {
                return 0;
            }
            customer.password = MatKhauMoi;
            if (customerDAO.Update(customer) > 0)
                return 1;
            return 0;
        }

        public int Update(int MaKH)
        {
            KhachHangDAO customerDAO = new KhachHangDAO();
            Customer customer = customerDAO.GetCustomerById(MaKH);
            return customerDAO.Update(customer);
        }
        public Customer Authenticate(string email, string MatKhau)
        {
            Customer customer = KhachHangDAO.GetByUserEmail(email);
            if (customer == null || !customer.password.Equals(MatKhau))
                return null;
            return customer;
        }

        public int Delete(int MaKH)
        {
            return KhachHangDAO.Delete(MaKH);
        }
    }
}