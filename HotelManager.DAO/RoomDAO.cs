using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DTO;

namespace HotelManager.DAO
{
    public class RoomDAO
    {
        private HotelManagerContext context;
        public RoomDAO()
        {
            context = new HotelManagerContext();
        }
        public List<Room> GetRoom()
        {
            List<Room> Room = context.Rooms.Where(r => r.DeleteFlg == 0).OrderByDescending(r => r.id).ToList();
            return Room;
        }

        public List<Room> GetRoomHome()
        {
            List<Room> Room = context.Rooms.Where(r => r.DeleteFlg == 0 && r.status == 0).OrderByDescending(r => r.id).ToList();
            return Room;
        }

        public List<Room> GetRoomByRoomType(int ID)
        {
            var query = context.Rooms.AsQueryable();
            List<Room> Room = query.Where(p => p.typeRoom == ID).ToList();

            return Room;
        }
        public Room ViewDetail(int id)
        {
            return context.Rooms.Find(id);
        }
        public List<Room> GetRoom(string keyword)
        {
            List<Room> Room = context.Rooms.Where(p => p.name.Contains(keyword)).ToList();
            return Room;
        }
        public void DeleteRoom(int id)
        {
            Room Room = context.Rooms.Find(id);

            if (Room != null)
            {
                // Kiểm tra xem sản phẩm có liên kết với bất kỳ hóa đơn nào không
                if (!context.Orders.Any(oi => oi.roomID == id))
                {
                    context.Rooms.Remove(Room);
                    context.SaveChanges();
                }
                else
                {

                    Room.DeleteFlg = 1;
                    context.SaveChanges();
                }
            }
        }
        public List<Room> GetRoom(Dictionary<string, string> queryParams)
        {
            var Room = context.Rooms.AsQueryable();

            if (queryParams.ContainsKey("kw"))
            {
                string keyword = queryParams["kw"];
                Room = Room.Where(p => p.name.Contains(keyword));
            }
            if (queryParams.ContainsKey("categoryId") && queryParams["categoryId"] != null)
            {
                int categoryId = int.Parse(queryParams["categoryId"]);
                Room = Room.Where(p => p.typeRoom == (int) categoryId);
            }

            return Room.ToList();
        }
        public void Create(Room Room)
        {
            try
            {
                context.Rooms.Add(Room);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the validation errors
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the error messages together
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Throw a new exception with the full error message
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        public bool UpdateInfo(Room Room, string name, float unitPrice, string description, float discount, string image, int quantity, int typeRoom)
        {
            try
            {
                Room.name = name;
                Room.unitPrice = unitPrice;
                Room.description = description;
                Room.discount = discount;
                Room.image = image;
                Room.quantity = quantity;
                Room.typeRoom = typeRoom;
                context.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateStatus(Room Room, int status)
        {
            try
            { 
                Room.status = status; 
                context.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Update(Room Room)
        {
            try
            {
                context.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Room GetRoomById(int id)
        {
            return context.Rooms.Find(id);
        }
        public Room AddRoom(Room Room)
        {
            try
            {
                context.Rooms.Add(Room);
                context.SaveChanges();
                return Room;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
