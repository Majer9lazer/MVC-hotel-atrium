using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAtr.DAL.Model
{
    public class ServiceRoom
    {
        private static readonly HotelAtrEntities Db = new HotelAtrEntities();
        public static bool AddRoom(Room room)
        {
            try
            {
                Db.Rooms.Add(room);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteRoom(int roomId)
        {
            Room findedRoom = Db.Rooms.Find(roomId);
            if (findedRoom != null)
            {
                try
                {
                    Db.Rooms.Remove(findedRoom);
                    Db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return false;
        }

    }
}
