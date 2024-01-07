using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DAO;
using HotelManager.DTO;

namespace HotelManager.BUS
{
    public class TypeRoomBUS
    {
        private TypeRoomDAO TypeRoomDAO;

        public TypeRoomBUS()
        {
            // Khởi tạo đối tượng TypeRoomDAO để truy xuất dữ liệu từ bảng Categories
            TypeRoomDAO = new TypeRoomDAO(); 
        }

        // Phương thức lấy danh sách các mục danh mục từ bảng Categories
        public List<TypeRoom> GetTypeRoom()
        {
            return TypeRoomDAO.GetTypeRoom();
        }

        // Phương thức lấy một mục danh mục từ bảng Categories theo ID
        public TypeRoom GetTypeRoomById(int TypeRoomId)
        {
            return TypeRoomDAO.GetTypeRoomById(TypeRoomId);
        }

        // Phương thức thêm một mục danh mục vào bảng Categories
        public void AddTypeRoom(TypeRoom TypeRoom)
        {
            TypeRoomDAO.AddTypeRoom(TypeRoom);
        }

        // Phương thức sửa một mục danh mục trong bảng Categories
        public void UpdateTypeRoom(TypeRoom TypeRoom)
        {
            TypeRoomDAO.UpdateTypeRoom(TypeRoom);
        }

        // Phương thức xoá một mục danh mục khỏi bảng Categories
        public bool DeleteTypeRoom(int TypeRoomId)
        {
            if (TypeRoomDAO.DeleteTypeRoom(TypeRoomId))
                return true;
            else
                return false;
        }
        public bool UpdateInfo(TypeRoom TypeRoom, string name)
        {
            try
            {
                // Gọi phương thức UpdateInfo() trên đối tượng repository
                TypeRoomDAO.UpdateInfo(TypeRoom, name);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
