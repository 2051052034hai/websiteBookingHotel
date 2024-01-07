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
    public class RoomBUS
    {
        private readonly RoomDAO RoomDAO;
        public RoomBUS()
        {
            RoomDAO = new RoomDAO();
        }
        public List<Room> GetRoom()
        {
            RoomDAO RoomDAO = new RoomDAO();
            return RoomDAO.GetRoom();
        }

        public List<Room> GetRoomHome()
        {
            RoomDAO RoomDAO = new RoomDAO();
            return RoomDAO.GetRoomHome();
        }
        public Room Add(Room Room)
        {
            return RoomDAO.AddRoom(Room);
        }
        public void Delete(int id )
        {
            RoomDAO.DeleteRoom(id);
        }
        public List<Room> GetRoom(string kw)
        {
            RoomDAO RoomDAO = new RoomDAO();
            return RoomDAO.GetRoom(kw);
        }
       
        public List<Room> GetRoom(Dictionary<string, string> queryParams)
        {
            RoomDAO RoomDAO = new RoomDAO();
            return RoomDAO.GetRoom(queryParams);
        }

        public object GetRoom(int? RoomID)
        {
            throw new NotImplementedException();
        }
        public List<Room> GetRoomByCateID(int roomTypeID)
        {
            return RoomDAO.GetRoomByRoomType(roomTypeID);
        }
        public bool UpdateRoomInfo(string id, string name, float unitPrice, string description, float discount, string image, int quantity, int typeRoom)
        {
            try
            {
                Room Room=RoomDAO.GetRoomById(int.Parse(id));
                return RoomDAO.UpdateInfo(Room, name, unitPrice, description, discount, image, quantity, typeRoom);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateStatus(Room room, int status)
        {
            try
            {
                Room Room = RoomDAO.GetRoomById(room.id);
                return RoomDAO.UpdateStatus(Room, status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Room GetRoom(int id)
        {
            RoomDAO RoomDAO = new RoomDAO();
            return RoomDAO.GetRoomById(id);
        }
    }
}
