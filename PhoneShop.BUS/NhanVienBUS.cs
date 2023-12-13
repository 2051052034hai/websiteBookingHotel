using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;
using PhoneShop.DAO;

namespace PhoneShop.BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAO NhanVienDAO;
        public NhanVienBUS()
        {
            NhanVienDAO = new NhanVienDAO();
        }

        public NhanVien_62132473 GetEmployeeById(int MaKH)
        {
            return NhanVienDAO.GetEmployeeById(MaKH);
        }

        public List<NhanVien_62132473> Getemployees()
        {
            return NhanVienDAO.GetAllEmployees();
        }

        public List<NhanVien_62132473> GetemployeesStaff()
        {
            return NhanVienDAO.GetAllEmployeesStaff();
        }

        public int Create(NhanVien_62132473 employee)
        {
            if (NhanVienDAO.GetByUserEmail(employee.email) != null)
                return 0;
            return NhanVienDAO.Create(employee);
        }
        public int Update(string MaKH, string HoTen, string SDT, string DiaChi, string MatKhau)
        {
            NhanVienDAO employeeDAO = new NhanVienDAO();
            NhanVien_62132473 employee = employeeDAO.GetEmployeeById(int.Parse(MaKH));
            employee.HoTen = HoTen;
            employee.SDT = SDT;
            employee.DiaChi = DiaChi;
            employee.MatKhau = MatKhau;

            if (employeeDAO.Update(employee) > 0)
                return 1;
            return 0;
        }
        public int Update(string MaKH, string MatKhau, string MatKhauMoi)
        {
            NhanVienDAO employeeDAO = new NhanVienDAO();
            NhanVien_62132473 employee = employeeDAO.GetEmployeeById(int.Parse(MaKH));
            if (!employee.MatKhau.Equals(MatKhau))
            {
                return 0;
            }
            employee.MatKhau = MatKhauMoi;
            if (employeeDAO.Update(employee) > 0)
                return 1;
            return 0;
        }

        public int Update(int MaNV)
        {
            NhanVienDAO employeeDAO = new NhanVienDAO();
            NhanVien_62132473 employee = employeeDAO.GetEmployeeById(MaNV);
            return employeeDAO.Update(employee);
        }
        public NhanVien_62132473 Authenticate(string email, string MatKhau)
        {
            NhanVien_62132473 employee = NhanVienDAO.GetByUserEmail(email);
            if (employee == null || !employee.MatKhau.Equals(MatKhau))
                return null;
            return employee;
        }

        public int Delete(int MaNV)
        {
            return NhanVienDAO.Delete(MaNV);
        }
    }
}
