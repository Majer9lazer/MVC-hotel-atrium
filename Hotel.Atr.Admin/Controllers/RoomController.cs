using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL.Model;

namespace Hotel.Atr.Admin.Controllers
{
    public class RoomController : BaseController
    {

        // GET: Room
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View(db.Rooms.ToList());

        }

        public ActionResult AddRoom()
        {
            ViewBag.RoomTypeList = db.RoomTypes.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.RoomTypeId.ToString()
            }).ToList();
            return View();
        }
        public ActionResult AddRoomSuccess(Room room)
        {
            if (room.Square != null)
                if (ServiceRoom.AddRoom(room))
                    return RedirectToAction("Index", "Room");

         
            return RedirectToAction("Index", "Room", new {mwssage = "Данные пришли пустымиЫ."});
        }

        public ActionResult EditRoom(int roomId)
        {
            Room findedRoom = db.Rooms.Find(roomId);
            if (findedRoom != null)
            {
                try
                {
                    return RedirectToAction("Index", "Room", new { message = "Данные успешно изменены." });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", "Room", new { message = e.ToString() });
                }
            }

            return RedirectToAction("Index", "Room", new { message = "Данные пришли пустыми." });

        }
        public ActionResult DeleteRoom(int roomId)
        {
            if (ServiceRoom.DeleteRoom(roomId))
            {
                return RedirectToAction("Index", "Room", new { message = "Good Delete" });
            }
            return RedirectToAction("Index", "Room");
        }
    }
}