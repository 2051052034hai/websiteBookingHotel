using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;
using PhoneShop.DAO;

namespace PhoneShop.BUS
{
    public class ChiTietGioHangBUS
    {
        private readonly ChiTietGioHangDAO ChiTietGioHangDAO;

        public ChiTietGioHangBUS()
        {
            ChiTietGioHangDAO = new ChiTietGioHangDAO();
        }
        public List<ChiTietGH_62132473> GetAll()
        {
            return ChiTietGioHangDAO.GetAll();
        }
    }
}
