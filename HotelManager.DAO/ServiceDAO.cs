using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DTO;

namespace HotelManager.DAO
{
    public class ServiceDAO
    {
        private HotelManagerContext context;
        public ServiceDAO()
        {
            context = new HotelManagerContext();
        }
        public List<Service> GetService()
        {
            List<Service> Service = context.Services.ToList();
            return Service;
        }
        // Phương thức lấy dịch vụ từ bảng Service theo ID
        public Service GetServiceById(int ServiceId)
        {
            return context.Services.Find(ServiceId);
        }

        // Phương thức thêm một dịch vụ bảng Service
        public void AddService(Service LoaiSP)
        {
            context.Services.Add(LoaiSP);
            context.SaveChanges();
        }
        public bool UpdateInfo(Service Service, string name, float unitPrice)
        {
            try
            {
                Service.name = name;
                Service.unitPrice = unitPrice;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Phương thức sửa thông tin dịch vụ từ bảng Service
        public void UpdateService(Service Service)
        {
            context.Entry(Service).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Phương thức xoá một dịch vụ khỏi bảng Service
        public bool DeleteService(int id)
        {
            try
            {
                Service Service = context.Services.Find(id);
                context.Services.Remove(Service);
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
