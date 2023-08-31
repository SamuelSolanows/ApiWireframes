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
    public class TEventosController : ApiController
    {
        private DBWireframesEntities db = new DBWireframesEntities();

        // GET: api/TEventos
        public IHttpActionResult GetTEventos()
        {
            return Ok(db.TEventos.Select(x => new Eventos()
            {
                Nombre = x.Nombre,
                ID = x.ID,
                Descripcion = x.Descripcion,
                Visto=x.Visto.Value,
                Imagen=x.Imagen

            }).ToList());
        }

        // GET: api/TEventos/5
        [ResponseType(typeof(TEventos))]
        public IHttpActionResult GetTEventos(int id)
        {
            TEventos tEventos = db.TEventos.Find(id);
            if (tEventos == null)
            {
                return NotFound();
            }

            return Ok(tEventos);
        }

        // PUT: api/TEventos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTEventos(int id, TEventos tEventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tEventos.ID)
            {
                return BadRequest();
            }

            db.Entry(tEventos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TEventosExists(id))
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

        // POST: api/TEventos
        [ResponseType(typeof(TEventos))]
        public IHttpActionResult PostTEventos(TEventos tEventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TEventos.Add(tEventos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tEventos.ID }, tEventos);
        }

        // DELETE: api/TEventos/5
        [ResponseType(typeof(TEventos))]
        public IHttpActionResult DeleteTEventos(int id)
        {
            TEventos tEventos = db.TEventos.Find(id);
            if (tEventos == null)
            {
                return NotFound();
            }

            db.TEventos.Remove(tEventos);
            db.SaveChanges();

            return Ok(tEventos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TEventosExists(int id)
        {
            return db.TEventos.Count(e => e.ID == id) > 0;
        }
    }
}