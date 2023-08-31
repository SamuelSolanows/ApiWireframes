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
    public class TImagensController : ApiController
    {
        private DBWireframesEntities db = new DBWireframesEntities();

        // GET: api/TImagens
        public IHttpActionResult GetTImagen()
        {
            return Ok(db.TImagen.Select(x=>new Imagenes()
            {
                ID = x.ID,
                ID_Evento =x.ID_Evento.Value,
                Imagen = x.Imagen,
            }));
        }

        // GET: api/TImagens/5
        [ResponseType(typeof(TImagen))]
        public IHttpActionResult GetTImagen(int id)
        {
            TImagen tImagen = db.TImagen.Find(id);
            if (tImagen == null)
            {
                return NotFound();
            }

            return Ok(tImagen);
        }

        // PUT: api/TImagens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTImagen(int id, TImagen tImagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tImagen.ID)
            {
                return BadRequest();
            }

            db.Entry(tImagen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TImagenExists(id))
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

        // POST: api/TImagens
        [ResponseType(typeof(TImagen))]
        public IHttpActionResult PostTImagen(TImagen tImagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TImagen.Add(tImagen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tImagen.ID }, tImagen);
        }

        // DELETE: api/TImagens/5
        [ResponseType(typeof(TImagen))]
        public IHttpActionResult DeleteTImagen(int id)
        {
            TImagen tImagen = db.TImagen.Find(id);
            if (tImagen == null)
            {
                return NotFound();
            }

            db.TImagen.Remove(tImagen);
            db.SaveChanges();

            return Ok(tImagen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TImagenExists(int id)
        {
            return db.TImagen.Count(e => e.ID == id) > 0;
        }
    }
}