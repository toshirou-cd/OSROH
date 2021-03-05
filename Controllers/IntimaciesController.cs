using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OSROH.Models;

namespace OSROH.Controllers
{
    public class IntimaciesController : ApiController
    {
        private BikeEntities db = new BikeEntities();

        // GET: api/Intimacies
        public IQueryable<Intimacy> GetIntimacies()
        {
            return db.Intimacies;
        }

        // GET: api/Intimacies/5
        [ResponseType(typeof(Intimacy))]
        public async Task<IHttpActionResult> GetIntimacy(string id)
        {
            Intimacy intimacy = await db.Intimacies.FindAsync(id);
            if (intimacy == null)
            {
                return NotFound();
            }

            return Ok(intimacy);
        }

        // PUT: api/Intimacies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIntimacy(string id, Intimacy intimacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intimacy.UserID1)
            {
                return BadRequest();
            }

            db.Entry(intimacy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntimacyExists(id))
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

        // POST: api/Intimacies
        [ResponseType(typeof(Intimacy))]
        public async Task<IHttpActionResult> PostIntimacy(Intimacy intimacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Intimacies.Add(intimacy);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IntimacyExists(intimacy.UserID1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = intimacy.UserID1 }, intimacy);
        }

        // DELETE: api/Intimacies/5
        [ResponseType(typeof(Intimacy))]
        public async Task<IHttpActionResult> DeleteIntimacy(string id)
        {
            Intimacy intimacy = await db.Intimacies.FindAsync(id);
            if (intimacy == null)
            {
                return NotFound();
            }

            db.Intimacies.Remove(intimacy);
            await db.SaveChangesAsync();

            return Ok(intimacy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntimacyExists(string id)
        {
            return db.Intimacies.Count(e => e.UserID1 == id) > 0;
        }
    }
}