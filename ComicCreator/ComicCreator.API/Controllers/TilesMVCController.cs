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
    public class TilesMVCController : Controller
    {
        private ComicCreatorDB db = new ComicCreatorDB();

        // GET: TilesMVC
        public ActionResult Index()
        {
            return View(db.Tiles.ToList());
        }

        // GET: TilesMVC/Details/5
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

        // GET: TilesMVC/Create
        public ActionResult Create()
        {
            ViewBag.Projects = new SelectList(db.Projects.ToList(), "ProjectId", "Title");
            return View();
        }

        // POST: TilesMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,Caption,URL,OrderNumber")] Tile tile, int projectid)
        {
            if (ModelState.IsValid)
            {
                var proj = db.Projects.Find(projectid);
                tile.Project = proj;
                tile.DateCreated = DateTime.Now;
                tile.DateUpdated = DateTime.Now;
                db.Tiles.Add(tile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tile);
        }

        // GET: TilesMVC/Edit/5
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

        // POST: TilesMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,Caption,URL,DateCreated,DateUpdated,OrderNumber")] Tile tile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tile);
        }

        // GET: TilesMVC/Delete/5
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

        // POST: TilesMVC/Delete/5
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
