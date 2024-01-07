using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DTO;

namespace HotelManager.DAO
{
    public class OrdersDAO
    {
        private HotelManagerContext context;
        public OrdersDAO()
        {
            context = new HotelManagerContext();
        }
        public List<Order> GetOrders()
        {
            List<Order> Order = context.Orders.ToList();
            return Order;
        }

        public List<Order> GetOrdersByCustomerID(int id)
        {
            List<Order> orders = context.Orders
                                .Where(o => o.customerID == id && o.status == 0)
                                .ToList();

            return orders;
        }

        /*  0 - Đơn hàng đã đc đặt
            1 - Đơn hàng bị huỷ
            2 - Đơn hàng đã hết thời gian đặt
        */
        public bool UpdateStatus(Order order, int status)
        {
            try
            {
                order.status = status;
                context.Entry(order).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Order GetOrderById(int id)
        {
            return context.Orders.Find(id);
        }

        public List<Order> GetAllRevenue()
        {
            var donHangList = context.Orders.Where(dh => dh.status != 1).ToList();
            return donHangList;
        }

        public int UpdateAdmin(Order order)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingBill = context.Orders.Find(order.id);
                    var existingRoom = context.Rooms.Find(order.roomID);

                    if (existingBill != null)
                    {
                        existingBill.status = order.status;
                    }

                    if (existingRoom != null)
                    {
                        existingRoom.status = 0;
                    }

                    context.SaveChanges();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
