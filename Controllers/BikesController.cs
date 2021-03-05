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
    public class BikesController : ApiController
    {
        private BikeEntities db = new BikeEntities();

        // GET: api/Bikes
        public IQueryable<Bike> GetBikes()
        {
            return db.Bikes;
        }

        // GET: api/Bikes/5
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> GetBike(string id)
        {
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        // PUT: api/Bikes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBike(string id, Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bike.ID)
            {
                return BadRequest();
            }

            db.Entry(bike).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
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

        // POST: api/Bikes
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> PostBike(Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bikes.Add(bike);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BikeExists(bike.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bike.ID }, bike);
        }

        // DELETE: api/Bikes/5
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> DeleteBike(string id)
        {
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            db.Bikes.Remove(bike);
            await db.SaveChangesAsync();

            return Ok(bike);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BikeExists(string id)
        {
            return db.Bikes.Count(e => e.ID == id) > 0;
        }
    }
}