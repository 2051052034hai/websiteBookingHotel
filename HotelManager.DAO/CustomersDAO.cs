using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class KhachHangDAO
    {
        private HotelManagerContext context;

        public KhachHangDAO()
        {
            this.context = new HotelManagerContext();
        }
        public List<Customer> GetAllCustomers()
        {
            return context.Customers.Where(kh => kh.roleID != 2 && kh.deleteFlg == 0).ToList();
        }

        public int Create(Customer KhachHang)
        {
            try
            {
                context.Customers.Add(KhachHang);
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
        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.Find(customerId);
        }
        public Customer ViewDetail(int id)
        {
            return context.Customers.Find(id);
        }
        // Update an existing customer
        public int Update(Customer customer)
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
                Customer KhachHang = GetCustomerById(MaKH);
                KhachHang.deleteFlg = 1;
                context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }


        public Customer GetByUserEmail(string email)
        {
            return context.Customers.FirstOrDefault(c => c.email == email);
        }
    }
}