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
using eshu_api.Models;

namespace eshu_api.Controllers
{
    public class COUNTRiesController : ApiController
    {
        private devtestdbEntities db = new devtestdbEntities();

        // GET: api/COUNTRies
        public IQueryable<COUNTRY> GetCOUNTRies()
        {
            return db.COUNTRies;
        }

        // GET: api/COUNTRies/5
        [ResponseType(typeof(COUNTRY))]
        public IHttpActionResult GetCOUNTRY(int id)
        {
            COUNTRY cOUNTRY = db.COUNTRies.Find(id);
            if (cOUNTRY == null)
            {
                return NotFound();
            }

            return Ok(cOUNTRY);
        }

        // PUT: api/COUNTRies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOUNTRY(int id, COUNTRY cOUNTRY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOUNTRY.CTRY_ID)
            {
                return BadRequest();
            }

            db.Entry(cOUNTRY).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COUNTRYExists(id))
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

        // POST: api/COUNTRies
        [ResponseType(typeof(COUNTRY))]
        public IHttpActionResult PostCOUNTRY(COUNTRY cOUNTRY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COUNTRies.Add(cOUNTRY);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cOUNTRY.CTRY_ID }, cOUNTRY);
        }

        // DELETE: api/COUNTRies/5
        [ResponseType(typeof(COUNTRY))]
        public IHttpActionResult DeleteCOUNTRY(int id)
        {
            COUNTRY cOUNTRY = db.COUNTRies.Find(id);
            if (cOUNTRY == null)
            {
                return NotFound();
            }

            db.COUNTRies.Remove(cOUNTRY);
            db.SaveChanges();

            return Ok(cOUNTRY);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COUNTRYExists(int id)
        {
            return db.COUNTRies.Count(e => e.CTRY_ID == id) > 0;
        }
    }
}