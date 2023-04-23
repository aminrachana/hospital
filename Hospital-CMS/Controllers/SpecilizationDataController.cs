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
    public class SpecilizationDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SpecilizationData/ListSpecilization
        //comments
        [HttpGet]
        public IEnumerable<SpecilizationDto> ListSpecilization()
        {
            List<Specilization> Specilizations= db.Specilization.ToList();
            List<SpecilizationDto> SpecilizationDtos = new List<SpecilizationDto>();

            Specilizations.ForEach(a => SpecilizationDtos.Add(new SpecilizationDto()
            {
                SpecilizationId =a.SpecilizationId,
                SpecilizationName=a.SpecilizationName
            }));

            return SpecilizationDtos;
        }

        // GET: api/SpecilizationData/FindSpecilization/5
        [ResponseType(typeof(Specilization))]
        [HttpGet]

        public IHttpActionResult FindSpecilization(int id)
        {
            Specilization specilization = db.Specilization.Find(id);
            if (specilization == null)
            {
                return NotFound();
            }

            return Ok(specilization);
        }

        // POST: api/SpecilizationData/UpdateSpecilization/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateSpecilization(int id, Specilization specilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specilization.SpecilizationId)
            {
                return BadRequest();
            }

            db.Entry(specilization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecilizationExists(id))
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

        // POST: api/SpecilizationData/AddSpecilization
        [ResponseType(typeof(Specilization))]
        [HttpPost]
        public IHttpActionResult AddSpecilization(Specilization specilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specilization.Add(specilization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = specilization.SpecilizationId }, specilization);
        }

        // POST: api/SpecilizationData/DeleteSpecilization/5
        [ResponseType(typeof(Specilization))]
        [HttpPost]
        public IHttpActionResult DeleteSpecilization(int id)
        {
            Specilization specilization = db.Specilization.Find(id);
            if (specilization == null)
            {
                return NotFound();
            }

            db.Specilization.Remove(specilization);
            db.SaveChanges();

            return Ok(specilization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecilizationExists(int id)
        {
            return db.Specilization.Count(e => e.SpecilizationId == id) > 0;
        }
    }
}