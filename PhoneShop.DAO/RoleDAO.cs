using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;

namespace PhoneShop.DAO
{
  
    public class RoleDAO
    {
        private PhoneContext context;

        public RoleDAO()
        {
            context = new PhoneContext();
        }

        public List<QuyenSD_62132473> GetRole_62132473()
        {
            List<QuyenSD_62132473> Role_62132473 = context.QuyenSD_62132473
             .Where(role => role.name != "ADMIN")
             .OrderByDescending(role => role.id)  
             .ToList();
            return Role_62132473;
        }
    }
}
