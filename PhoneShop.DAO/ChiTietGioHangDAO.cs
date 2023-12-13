using PhoneShop.DTO;
using PhoneShop.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.DAO
{
   
    public class ChiTietGioHangDAO
    {
        private readonly PhoneContext context;
        public ChiTietGioHangDAO()
        {
            context = new PhoneContext();
        }

        public List<ChiTietGH_62132473> GetAll()
        {
            return context.ChiTietGH_62132473.ToList();
        }
    }
}
