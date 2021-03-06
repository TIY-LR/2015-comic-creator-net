﻿using System;
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
    public class ProjectsController : ApiController
    {
        private ComicCreatorDB db = new ComicCreatorDB();

        // GET: api/Projects
        public IHttpActionResult GetProjects()
        {
            var model = db.Projects.Include("tiles").ToList().Select(p => new GetProjectInfoVM(p));

            return Ok(model);
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = db.Projects.Include("Tiles").Where(x => x.Id == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }

            var model = new GetProjectInfoVM(project);
            return Ok(model);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != project.Id)
            //{
            //    return BadRequest();
            //}

            project.DateCreated = DateTime.Now;
            project.DateUpdated = DateTime.Now;

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            project.DateCreated = DateTime.Now;
            project.DateUpdated = DateTime.Now;



            db.Projects.Add(project);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        public void DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return;
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}