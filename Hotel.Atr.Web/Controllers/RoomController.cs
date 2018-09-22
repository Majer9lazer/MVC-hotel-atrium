using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Hotel.Atr.Web.Models.Model;
//using HotelAtr.DAL.Model;

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

        public ActionResult RoomDetails(int? roomId)
        {
            if (roomId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Room foundElement = _dbAtrEntities.Rooms.Find(roomId);
            if (foundElement == null)
            {
                
                return HttpNotFound();
            }

            return View("RoomDetails", foundElement);
        }
    }
}