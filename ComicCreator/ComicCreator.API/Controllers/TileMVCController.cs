using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicCreator.API.Models;

namespace ComicCreator.API.Controllers
{
    public class TileMVCController : Controller
    {
        private ComicCreatorDB db = new ComicCreatorDB();

        // GET: TileMVC
        public ActionResult Index()
        {
            return View(db.Tiles.ToList());
        }

        // GET: TileMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tile tile = db.Tiles.Find(id);
            if (tile == null)
            {
                return HttpNotFound();
            }
            return View(tile);
        }

        // GET: TileMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TileMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,DateCreated,DateUpdated,OrderNumber")] Tile tile)
        {
            if (ModelState.IsValid)
            {
                db.Tiles.Add(tile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tile);
        }

        // GET: TileMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tile tile = db.Tiles.Find(id);
            if (tile == null)
            {
                return HttpNotFound();
            }
            return View(tile);
        }

        // POST: TileMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,DateCreated,DateUpdated,OrderNumber")] Tile tile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tile);
        }

        // GET: TileMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tile tile = db.Tiles.Find(id);
            if (tile == null)
            {
                return HttpNotFound();
            }
            return View(tile);
        }

        // POST: TileMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tile tile = db.Tiles.Find(id);
            db.Tiles.Remove(tile);
            db.SaveChanges();
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
