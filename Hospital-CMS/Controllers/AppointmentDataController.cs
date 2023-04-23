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
    public class AppointmentDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AppointmentData/ListAppointments
        //curl https://localhost:44370/api/appointmentdata/Listappointments
        [HttpGet]
        public IEnumerable<AppointmentDto> ListPatients()
        {
            List<Appointment> Appointments = db.Appointments.ToList();
            List<AppointmentDto> AppointmentDtos = new List<AppointmentDto>();

            Appointments.ForEach(p => AppointmentDtos.Add(new AppointmentDto()
            {
                AppointmentId = p.AppointmentId,
                AppointmentDate = p.AppointmentDate,
                AppointmentTime = p.AppointmentTime,
                CheckIn = p.CheckIn,
                
                
                RoomType = p.Room.RoomType
            }));

            return AppointmentDtos;
        }

        // GET: api/AppointmentData/FindAppointment/5
        //curl https://localhost:44370/api/appointmentdata/findappointment/2
        [ResponseType(typeof(Appointment))]
        [HttpGet]
        public IHttpActionResult FindAppointment(int id)
        {
            Appointment Appointment = db.Appointments.Find(id);
            AppointmentDto AppointmentDto = new AppointmentDto()
            {
                AppointmentId = Appointment.AppointmentId,
                AppointmentDate = Appointment.AppointmentDate,
                AppointmentTime = Appointment.AppointmentTime,
                CheckIn = Appointment.CheckIn,


                RoomType = Appointment.Room.RoomType
            };
            if (Appointment == null)
            {
                return NotFound();
            }

            return Ok(AppointmentDto);
        }

        // PUT: api/AppointmentData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: api/AppointmentData
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointments.Add(appointment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appointment.AppointmentId }, appointment);
        }

        // DELETE: api/AppointmentData/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(int id)
        {
            return db.Appointments.Count(e => e.AppointmentId == id) > 0;
        }
    }
}