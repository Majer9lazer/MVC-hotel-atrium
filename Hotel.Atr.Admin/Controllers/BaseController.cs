using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL.Model;

namespace Hotel.Atr.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected HotelAtrEntities db = new HotelAtrEntities();
    }
}