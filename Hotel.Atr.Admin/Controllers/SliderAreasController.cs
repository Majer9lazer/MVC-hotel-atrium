using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL.Model;

namespace Hotel.Atr.Admin.Controllers
{
    public class SliderAreasController : Controller
    {
        private HotelAtrEntities db = new HotelAtrEntities();

        // GET: SliderAreas
        public async Task<ActionResult> Index()
        {
            return View(await db.SliderAreas.ToListAsync());
        }

        // GET: SliderAreas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderArea sliderArea = await db.SliderAreas.FindAsync(id);
            if (sliderArea == null)
            {
                return HttpNotFound();
            }
            return View(sliderArea);
        }

        // GET: SliderAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SliderAreaId,Header,Description,Url,PathImg")] SliderArea sliderArea)
        {
            if (ModelState.IsValid)
            {
                db.SliderAreas.Add(sliderArea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sliderArea);
        }

        // GET: SliderAreas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderArea sliderArea = await db.SliderAreas.FindAsync(id);
            if (sliderArea == null)
            {
                return HttpNotFound();
            }
            return View(sliderArea);
        }

        // POST: SliderAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SliderAreaId,Header,Description,Url,PathImg")] SliderArea sliderArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sliderArea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sliderArea);
        }

        // GET: SliderAreas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderArea sliderArea = await db.SliderAreas.FindAsync(id);
            if (sliderArea == null)
            {
                return HttpNotFound();
            }
            return View(sliderArea);
        }

        // POST: SliderAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SliderArea sliderArea = await db.SliderAreas.FindAsync(id);
            if (sliderArea != null)
            {
                db.SliderAreas.Remove(sliderArea);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }



        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
