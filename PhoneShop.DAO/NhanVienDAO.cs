using PhoneShop.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.DAO
{
    public class NhanVienDAO
    {
        private PhoneContext context;

        public NhanVienDAO()
        {
            this.context = new PhoneContext();
        }
        public List<NhanVien_62132473> GetAllEmployees()
        {
            return context.NhanVien_62132473.Where(nv => nv.xoa == 0).ToList();
        }

        public List<NhanVien_62132473> GetAllEmployeesStaff()
        {
            return context.NhanVien_62132473.Where(nv => nv.QuyenSD == 2).ToList();
        }
        public int Create(NhanVien_62132473 NhanVien)
        {
            try
            {
                context.NhanVien_62132473.Add(NhanVien);
                return context.SaveChanges();
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
                return 0;
            }
        }

        // Read a Employee by ID
        public NhanVien_62132473 GetEmployeeById(int EmployeeId)
        {
            return context.NhanVien_62132473.Find(EmployeeId);
        }
        public NhanVien_62132473 ViewDetail(int id)
        {
            return context.NhanVien_62132473.Find(id);
        }
        // Update an existing Employee
        public int Update(NhanVien_62132473 Employee)
        {
            try
            {
                context.Entry(Employee).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int MaNV)
        {
                try
                {
                    NhanVien_62132473 NhanVien = GetEmployeeById(MaNV);
                    NhanVien.xoa = 1;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception)
                {

                    return 0;
                }
           
        }


        public NhanVien_62132473 GetByUserEmail(string email)
        {
            return context.NhanVien_62132473.FirstOrDefault(c => c.email == email);
        }
    }
}
