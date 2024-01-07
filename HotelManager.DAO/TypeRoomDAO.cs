using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DTO;

namespace HotelManager.DAO
{
    public class TypeRoomDAO
    {
        private HotelManagerContext context;

        public TypeRoomDAO()
        {
            // Khởi tạo đối tượng DbContext để truy xuất cơ sở dữ liệu
            context = new HotelManagerContext(); 
        }

        // Phương thức lấy danh sách các mục danh mục từ bảng TypeRoom
        public List<TypeRoom> GetTypeRoom()
        {
            return context.TypeRooms.OrderByDescending(tr => tr.id).ToList();
        }

        // Phương thức lấy một mục danh mục từ bảng TypeRoom theo ID
        public TypeRoom GetTypeRoomById(int TypeRoomId)
        {
            return context.TypeRooms.Find(TypeRoomId);
        }

        // Phương thức thêm một mục danh mục vào bảng TypeRoom
        public void AddTypeRoom(TypeRoom LoaiSP)
        {
            context.TypeRooms.Add(LoaiSP);
            context.SaveChanges();
        }
        public bool UpdateInfo(TypeRoom typeRoom, string name)
        {
            try
            {
                typeRoom.name = name;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Phương thức sửa một mục danh mục trong bảng TypeRoom
        public void UpdateTypeRoom(TypeRoom typeRoom)
        {
            context.Entry(typeRoom).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Phương thức xoá một mục danh mục khỏi bảng TypeRoom
        public bool DeleteTypeRoom(int id)
        {
            try
            {
                TypeRoom TypeRoom = context.TypeRooms.Find(id);
                context.TypeRooms.Remove(TypeRoom);
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
