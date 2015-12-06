using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ComicCreator.API.Models;

namespace ComicCreator.API.Controllers
{
    public class TilesController : ApiController
    {
        private ComicCreatorDB db = new ComicCreatorDB();

        // GET: api/Tiles
        public IQueryable<Tile> GetTiles()
        {
            return db.Tiles;
        }

        // GET: api/Tiles
        [HttpGet]
        [Route("api/tiles/{projectId}")]
        public IQueryable<Tile> GetTiles(int projectId)
        {
            return db.Tiles.Where(t=> t.Project.Id== projectId);
        }

        // GET: api/Tiles/5
        [ResponseType(typeof(Tile))]
        public IHttpActionResult GetTile(int id)
        {
            Tile tile = db.Tiles.Find(id);
            if (tile == null)
            {
                return NotFound();
            }

            return Ok(tile);
        }

        // PUT: api/Tiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTile(int id, Tile tile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tile.Id)
            {
                return BadRequest();
            }

            db.Entry(tile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tiles
        [ResponseType(typeof(Tile))]
        public IHttpActionResult PostTile(Tile tile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             tile.DateUpdated = DateTime.Now;
             tile.DateCreated = DateTime.Now;
            db.Tiles.Add(tile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tile.Id }, tile);
        }

        // DELETE: api/Tiles/5
        [ResponseType(typeof(Tile))]
        public IHttpActionResult DeleteTile(int id)
        {
            Tile tile = db.Tiles.Find(id);
            if (tile == null)
            {
                return NotFound();
            }

            db.Tiles.Remove(tile);
            db.SaveChanges();

            return Ok(tile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TileExists(int id)
        {
            return db.Tiles.Count(e => e.Id == id) > 0;
        }
    }
}