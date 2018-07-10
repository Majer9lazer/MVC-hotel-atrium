using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelAtr.DAL.Model;

namespace Hotel.Atr.Web.Models
{
    public class LayoutModel
    {
        private readonly HotelAtrEntities _dbEntities = new HotelAtrEntities();
        public List<Room> Rooms;
        public List<RoomType> RoomTypes;
        public List<SliderArea> SliderAreas;
        public List<Service> Services;

        public LayoutModel()
        {
            Rooms = _dbEntities.Rooms.ToList();
            SliderAreas = _dbEntities.SliderAreas.ToList();
            RoomTypes = _dbEntities.RoomTypes.ToList();
            Services = _dbEntities.Services.ToList();
        }

    }
}