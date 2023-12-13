using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneShop.DTO;
using PhoneShop.DAO;
using System.Data.Entity.Core.Mapping;

namespace PhoneShop.BUS
{
    public class RoleBUS
    {
        private readonly RoleDAO RoleDAO;

        public RoleBUS()
        {
            RoleDAO = new RoleDAO();
        }

        public List<QuyenSD_62132473> GetRole_62132473()
        {
            RoleDAO RoleDAO = new RoleDAO();
            return RoleDAO.GetRole_62132473();
        }
    }
}
