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
using ApiWireframes.Models;
using ApiWireframes.Models.view;

namespace ApiWireframes.Controllers
{
    public class TTicketsController : ApiController
    {
        private DBWireframesEntities db = new DBWireframesEntities();

        // GET: api/TTickets
        public IHttpActionResult GetTTicket()
        {
            return Ok(db.TTicket.ToList().Select(x => new Tickets()
            {
                User_Name = x.User_Name,
                Silla = x.Silla,
                Fecha = x.Fecha.Value,
                ID = x.ID,
                ID_Evento = x.ID_Evento.Value,
                eventos =new Eventos()
                {
                    Nombre = x.TEventos.Nombre,
                    Descripcion = x.TEventos.Descripcion,
                    Visto = x.TEventos.Visto.Value
                }


            }).ToList());
        }


        // GET: api/TTickets/5
        [ResponseType(typeof(TTicket))]
        public IHttpActionResult GetTTicket(int id)
        {
            TTicket tTicket = db.TTicket.Find(id);
            if (tTicket == null)
            {
                return NotFound();
            }

            return Ok(tTicket);
        }

        // PUT: api/TTickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTTicket(int id, TTicket tTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTicket.ID)
            {
                return BadRequest();
            }

            db.Entry(tTicket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTicketExists(id))
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

        // POST: api/TTickets
        [ResponseType(typeof(TTicket))]
        public IHttpActionResult PostTTicket(TTicket tTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TTicket.Add(tTicket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tTicket.ID }, tTicket);
        }

        // DELETE: api/TTickets/5
        [ResponseType(typeof(TTicket))]
        public IHttpActionResult DeleteTTicket(int id)
        {
            TTicket tTicket = db.TTicket.Find(id);
            if (tTicket == null)
            {
                return NotFound();
            }

            db.TTicket.Remove(tTicket);
            db.SaveChanges();

            return Ok(tTicket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TTicketExists(int id)
        {
            return db.TTicket.Count(e => e.ID == id) > 0;
        }
    }
}