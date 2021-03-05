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
    public class StationsController : ApiController
    {
        private BikeEntities db = new BikeEntities();

        // GET: api/Stations
        public IQueryable<Station> GetStations()
        {
            return db.Stations;
        }

        // GET: api/Stations/5
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> GetStation(string id)
        {
            Station station = await db.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        // PUT: api/Stations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStation(string id, Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != station.ID)
            {
                return BadRequest();
            }

            db.Entry(station).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // POST: api/Stations
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> PostStation(Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stations.Add(station);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StationExists(station.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = station.ID }, station);
        }

        // DELETE: api/Stations/5
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> DeleteStation(string id)
        {
            Station station = await db.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            db.Stations.Remove(station);
            await db.SaveChangesAsync();

            return Ok(station);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationExists(string id)
        {
            return db.Stations.Count(e => e.ID == id) > 0;
        }
    }
}