﻿using System.Web.Mvc;
using Hotel.Atr.Web.Models;
using Hotel.Atr.Web.Models.Model;
//using HotelAtr.DAL.Model;

namespace Hotel.Atr.Web.Controllers
{
    public class HomeController : Controller
    {
        private HotelAtrEntities _dbAtrEntities = new HotelAtrEntities();
        private readonly LayoutModel _model;
        public HomeController()
        {
            _model = new LayoutModel();
        }
        public ActionResult Index()
        {
            return View(_model);
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

        //public ActionResult RoomDetails()
        //{
        //    return View("roomDetails");
        //}
    }
}