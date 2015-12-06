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
        public IHttpActionResult GetTiles()
        {
            return Ok(db.Tiles.Include("Project").Select( t=> new GetTileInfoVM(t)));
        }

        //// GET: api/Tiles
        //[HttpGet]
        //[Route("api/tiles/{projectId}")]
        //public IQueryable<Tile> GetTiles(int projectId)
        //{
        //    return db.Tiles.Where(t=> t.Project.Id== projectId);
        //}

        // GET: api/Tiles/5
        [ResponseType(typeof(Tile))]
        public IHttpActionResult GetTile(int id)
        {
            Tile tile = db.Tiles.Find(id);
            if (tile == null)
            {
                return NotFound();
            }

            var model = new GetTileInfoVM(tile);
            return Ok(model);
        }

        // PUT: api/Tiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTile(int id, Tile tile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tile.DateCreated = DateTime.Now;
            tile.DateUpdated = DateTime.Now;

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
        public IHttpActionResult PostTile(CreateTitleVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = db.Projects.Find(model.Project);
            if (project == null)
            {
                return BadRequest($"Unable to find project with id {model.Project}");
            }

            var newTile = new Tile()
            {
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                OrderNumber = model.OrderNumber,
                Project = project,
                URL = model.URL,
                Caption = model.Caption

            };

            db.Tiles.Add(newTile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newTile.Id }, newTile);
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
