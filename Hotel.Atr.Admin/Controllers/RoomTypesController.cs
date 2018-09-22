using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Atr.Web.Models.Model;
using WebGrease.Activities;

namespace Hotel.Atr.Admin.Controllers
{
    public class RoomTypesController : BaseController
    {

        // GET: RoomTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.RoomTypes.ToListAsync());
        }

        // GET: RoomTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomType = await db.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }

        // GET: RoomTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RoomTypeId,Name,RoomTypeDescription,Price,Imagepath")] RoomType roomType, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        string path = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.FullName + @"\Hotel.Atr.Web\Content\img\room", Path.GetFileName(file.FileName));
                        if (!System.IO.File.Exists(path))
                            file.SaveAs(path);
                        roomType.Imagepath = Path.Combine(@"\Content\img\room", Path.GetFileName(file.FileName));

                        db.RoomTypes.Add(roomType);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                return View(roomType);
            }
            return View(roomType);
        }

        // GET: RoomTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomType = await db.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RoomTypeId,Name,RoomTypeDescription,Price,Imagepath")] RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roomType);
        }

        // GET: RoomTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomType = await db.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RoomType roomType = await db.RoomTypes.FindAsync(id);
            db.RoomTypes.Remove(roomType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
