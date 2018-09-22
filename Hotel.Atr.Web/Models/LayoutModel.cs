using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Atr.Web.Models.Model;
//using HotelAtr.DAL.Model;

namespace Hotel.Atr.Web.Models
{
    public class LayoutModel
    {
        private readonly HotelAtrEntities _dbEntities = new HotelAtrEntities();
        public List<Room> Rooms;
        public List<RoomType> RoomTypes;
        public List<SliderArea> SliderAreas;
        public List<Service> Services;
        public Random Rnd;
        public LayoutModel()
        {
            Rooms = _dbEntities.Rooms.ToList();
            SliderAreas = _dbEntities.SliderAreas.ToList();
            RoomTypes = _dbEntities.RoomTypes.ToList();
            Services = _dbEntities.Services.ToList();
            Rnd = new Random();
        }

    }
}