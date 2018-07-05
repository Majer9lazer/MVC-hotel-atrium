using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Atr.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnnualReport()
        {
            string filename = @"C:\Users\Mi Notebook\OneDrive\Документы\StepProject MVC\Материал\Soderzhanie.pdf";
            string ContentType = "application/pdf";
            string downloadName = "AnnualReport2018.pdf";

            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;  filename=CoefficientOfTechnicalReadiness.xlsm");
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.BinaryWrite(package.GetAsByteArray());
            //Response.End();



            return File(filename, ContentType, downloadName);
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