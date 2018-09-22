using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hotel.Atr.Web.Models.Model;
using HotelAtr.DAL.Model;

namespace Hotel.Atr.Web.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        private readonly HotelAtrEntities _dbAtrEntities = new HotelAtrEntities();
        public ActionResult Index()
        {
            return View(_dbAtrEntities.Rooms);
        }

        public async Task<ActionResult> RoomDetails(int? roomId)
        {
            if (roomId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Room findedElement = await _dbAtrEntities.Rooms.FindAsync(roomId);
            if (findedElement == null)
                return HttpNotFound();
            return View(findedElement);
        }
    }
}