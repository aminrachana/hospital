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
using Hospital_CMS.Models;

namespace Hospital_CMS.Controllers
{
    public class DischargeDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DischargeData
        public IQueryable<Discharge> GetDischarges()
        {
            return db.Discharges;
        }

        // GET: api/DischargeData/5
        [ResponseType(typeof(Discharge))]
        public IHttpActionResult GetDischarge(int id)
        {
            Discharge discharge = db.Discharges.Find(id);
            if (discharge == null)
            {
                return NotFound();
            }

            return Ok(discharge);
        }

        // PUT: api/DischargeData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDischarge(int id, Discharge discharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discharge.DischargeId)
            {
                return BadRequest();
            }

            db.Entry(discharge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DischargeExists(id))
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

        // POST: api/DischargeData
        [ResponseType(typeof(Discharge))]
        public IHttpActionResult PostDischarge(Discharge discharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Discharges.Add(discharge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = discharge.DischargeId }, discharge);
        }

        // DELETE: api/DischargeData/5
        [ResponseType(typeof(Discharge))]
        public IHttpActionResult DeleteDischarge(int id)
        {
            Discharge discharge = db.Discharges.Find(id);
            if (discharge == null)
            {
                return NotFound();
            }

            db.Discharges.Remove(discharge);
            db.SaveChanges();

            return Ok(discharge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DischargeExists(int id)
        {
            return db.Discharges.Count(e => e.DischargeId == id) > 0;
        }
    }
}