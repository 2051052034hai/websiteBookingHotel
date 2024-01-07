using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.DTO;
using HotelManager.BUS;
namespace HotelManager.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            TypeRoom typeRoom = new TypeRoom();
            TypeRoomBUS typeRoomBUS = new TypeRoomBUS();
            KhachHangBUS customerBus = new KhachHangBUS();
            Order order = new Order();
            OrdersBUS ordersBUS = new OrdersBUS();

            // Tính toán doanh thu cho từng loại phòng
            List<Room> products = new List<Room>();
            List<Order> orders = new List<Order>();

            orders = ordersBUS.GetOrders();

            var groupedByType = orders
            .GroupBy(detail => detail.Room.typeRoom)
            .Select(group => new ProductRevenueViewModel
            {
                ProductType = group.Key,
                TypeName = typeRoomBUS.GetTypeRoomById(group.Key).name,
                TotalRevenue = group.Sum(detail => detail.total)
            })
            .ToList();

            // Tính toán doanh thu theo người mua hàng đầu
            var revenueByUser = ordersBUS.GetAllRevenue();
            var customerTotalRevenue = revenueByUser
                .Where(item => item?.customerID != null)
                .GroupBy(item => (int)item.customerID)
                .ToDictionary(
                    group => group.Key,
                    group => new
                    {
                        CustomerName = customerBus.GetCustomerById(group.Key)?.name ?? "Unknown",
                        TotalRevenue = group.Sum(detail => detail.total)
                    }
                );

            var top5Customers = customerTotalRevenue
                .OrderByDescending(entry => entry.Value.TotalRevenue)
                .Take(5)
                .ToList();

            var resultArray = top5Customers
                .Select(pair => new ProductRevenueViewModel
                {
                    ProductType = pair.Key,
                    TypeName = pair.Value.CustomerName,
                    TotalRevenue = pair.Value.TotalRevenue
                })
                .ToArray();


            ViewBag.revenueByUser = resultArray;
            ViewBag.revenueByType = groupedByType;
            return View();

        }
    }
}