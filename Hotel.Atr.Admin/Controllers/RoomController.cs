using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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


            return RedirectToAction("Index", "Room", new { mwssage = "Данные пришли пустымиЫ." });
        }

        public async Task<ActionResult> Edit(int? roomId)
        {
            if (roomId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return HttpNotFound();
            }

            ViewData["RoomTypeId"] = new SelectList(db.RoomTypes, "RoomTypeId", "Name");
            return View(room);
        }
        public async Task<ActionResult> EditRoom([Bind(Include = "RoomId,RoomTypeId,Square,MaxPersons,IsFreeWifi,IsPrivateBalcony,IsFullAC,Floor,HasTV,IsBeachView")] Room room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(room).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Room", new { message = "Данные успешно изменены." });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", "Room", new { message = e.ToString() });
                }
            }

            return View("Edit", room);

        }
        public ActionResult DeleteRoom(int roomId)
        {
            if (ServiceRoom.DeleteRoom(roomId))
            {
                return RedirectToAction("Index", "Room", new { message = "Good Delete" });
            }
            return RedirectToAction("Index", "Room");
        }
        public async Task<ActionResult> Details(int? roomId)
        {
            if (roomId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }
    }
}