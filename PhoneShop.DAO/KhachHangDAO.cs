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
    public class KhachHangDAO
    {
        private PhoneContext context;

        public KhachHangDAO()
        {
            this.context = new PhoneContext();
        }
        public List<KhachHang_62132473> GetAllCustomers()
        {
            return context.KhachHang_62132473.Where(kh => kh.xoa == 0).ToList();
        }

        public int Create(KhachHang_62132473 KhachHang)
        {
            try
            {
                context.KhachHang_62132473.Add(KhachHang);
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

        // Read a customer by ID
        public KhachHang_62132473 GetCustomerById(int customerId)
        {
            return context.KhachHang_62132473.Find(customerId);
        }
        public KhachHang_62132473 ViewDetail(int id)
        {
            return context.KhachHang_62132473.Find(id);
        }
        // Update an existing customer
        public int Update(KhachHang_62132473 customer)
        {
            try
            {
                context.Entry(customer).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int MaKH)
        {   
                try
                {
                    KhachHang_62132473 KhachHang = GetCustomerById(MaKH);
                    KhachHang.xoa = 1;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception)
                {
                   
                    return 0;
                }
        }


        public KhachHang_62132473 GetByUserEmail(string email)
        {
            return context.KhachHang_62132473.FirstOrDefault(c => c.Email == email);
        }
    }
}
