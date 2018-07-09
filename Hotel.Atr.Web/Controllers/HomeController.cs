using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL.Model;

namespace Hotel.Atr.Web.Controllers
{
    public class HomeController : Controller
    {
        private HotelAtrEntities _dbAtrEntities = new HotelAtrEntities();
        public ActionResult Index()
        {
            ViewData["SliderArea"] = _dbAtrEntities.SliderAreas.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}