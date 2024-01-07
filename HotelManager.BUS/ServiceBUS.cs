using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DTO;
using HotelManager.DAO;
using System.Data.Entity.Core.Mapping;

namespace HotelManager.BUS
{
    public class ServiceBUS
    {
        private readonly ServiceDAO ServiceDAO;
        public ServiceBUS()
        {
            ServiceDAO = new ServiceDAO();
        }
        public List<Service> GetService()
        {
            ServiceDAO ServiceDAO = new ServiceDAO();
            return ServiceDAO.GetService();
        }


        // Phương thức lấy dịch vụ từ bảng service theo ID
        public Service GetserviceById(int serviceID)
        {
            return ServiceDAO.GetServiceById(serviceID);
        }

        // Phương thức thêm một dịch vụ vào bảng service
        public void AddService(Service Service)
        {
            ServiceDAO.AddService(Service);
        }

        // Phương thức sửa một loại dịch vụ trong bảng service
        public void UpdateService(Service Service)
        {
            ServiceDAO.UpdateService(Service);
        }

        // Phương thức xoá loại dịch vụ khỏi bảng service
        public bool DeleteService(int ServiceId)
        {
            if (ServiceDAO.DeleteService(ServiceId))
                return true;
            else
                return false;
        }
        public bool UpdateInfo(Service Service, string name, float unitPrice)
        {
            try
            {
                ServiceDAO.UpdateInfo(Service, name, unitPrice);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
