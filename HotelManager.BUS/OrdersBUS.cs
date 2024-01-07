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
    public class OrdersBUS
    {
        private readonly OrdersDAO OrdersDAO;
        public OrdersBUS()
        {
            OrdersDAO = new OrdersDAO();
        }
        public List<Order> GetOrders()
        {
            OrdersDAO OrdersDAO = new OrdersDAO();
            return OrdersDAO.GetOrders();
        }
        public List<Order> GetOrdersByCustomerID(int id)
        {
            return OrdersDAO.GetOrdersByCustomerID(id);
        }

        public bool UpdateStatus(Order order, int status)
        {
            try
            {
                Order Order = OrdersDAO.GetOrderById(order.id);
                return OrdersDAO.UpdateStatus(Order, status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Order GetOrderByID(int id)
        {
            OrdersDAO odersDAO = new OrdersDAO();
            return odersDAO.GetOrderById(id);
        }

        public List<Order> GetAllRevenue()
        {
            return OrdersDAO.GetAllRevenue();
        }

        public int UpdateAdmin(Order order)
        {
            try
            {
                OrdersDAO.UpdateAdmin(order);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
