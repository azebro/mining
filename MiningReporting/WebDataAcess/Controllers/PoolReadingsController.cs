using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;
using WebDataAcess.Models;

namespace WebDataAcess.Controllers
{
    
    
    public class PoolReadingsController : ApiController
    {
        private MiningEntities db = new MiningEntities();

        // GET: api/PoolReadings
        
        public IQueryable<PoolReading> GetPoolReadings()
        {
            return db.PoolReadings;
        }

        // GET: api/PoolReadings/5
        [ResponseType(typeof(Payment))]
        public IHttpActionResult GetPoolReading(int id)
        {
            Payment poolReading = db.Payments.First();
            if (poolReading == null)
            {
                return NotFound();
            }

            return Ok(poolReading);
        }

        // PUT: api/PoolReadings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoolReading(Guid id, PoolReading poolReading)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poolReading.ReadingId)
            {
                return BadRequest();
            }

            db.Entry(poolReading).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolReadingExists(id))
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

        // POST: api/PoolReadings
        [ResponseType(typeof(PoolReading))]
        public IHttpActionResult PostPoolReading(PoolReading poolReading)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoolReadings.Add(poolReading);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PoolReadingExists(poolReading.ReadingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = poolReading.ReadingId }, poolReading);
        }

        // DELETE: api/PoolReadings/5
        [ResponseType(typeof(PoolReading))]
        public IHttpActionResult DeletePoolReading(Guid id)
        {
            PoolReading poolReading = db.PoolReadings.Find(id);
            if (poolReading == null)
            {
                return NotFound();
            }

            db.PoolReadings.Remove(poolReading);
            db.SaveChanges();

            return Ok(poolReading);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoolReadingExists(Guid id)
        {
            return db.PoolReadings.Count(e => e.ReadingId == id) > 0;
        }
    }
}