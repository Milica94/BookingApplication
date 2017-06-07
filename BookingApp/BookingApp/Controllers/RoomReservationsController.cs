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
using BookingApp.Models;

namespace BookingApp.Controllers
{
    public class RoomReservationsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/RoomReservations
        public IQueryable<RoomReservations> GetRoomReservations()
        {
            return db.RoomReservations;
        }

        // GET: api/RoomReservations/5
        [ResponseType(typeof(RoomReservations))]
        public IHttpActionResult GetRoomReservations(int id)
        {
            RoomReservations roomReservations = db.RoomReservations.Find(id);
            if (roomReservations == null)
            {
                return NotFound();
            }

            return Ok(roomReservations);
        }

        // PUT: api/RoomReservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoomReservations(int id, RoomReservations roomReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomReservations.RoomReservationsId)
            {
                return BadRequest();
            }

            db.Entry(roomReservations).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomReservationsExists(id))
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

        // POST: api/RoomReservations
        [ResponseType(typeof(RoomReservations))]
        public IHttpActionResult PostRoomReservations(RoomReservations roomReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomReservations.Add(roomReservations);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roomReservations.RoomReservationsId }, roomReservations);
        }

        // DELETE: api/RoomReservations/5
        [ResponseType(typeof(RoomReservations))]
        public IHttpActionResult DeleteRoomReservations(int id)
        {
            RoomReservations roomReservations = db.RoomReservations.Find(id);
            if (roomReservations == null)
            {
                return NotFound();
            }

            db.RoomReservations.Remove(roomReservations);
            db.SaveChanges();

            return Ok(roomReservations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomReservationsExists(int id)
        {
            return db.RoomReservations.Count(e => e.RoomReservationsId == id) > 0;
        }
    }
}