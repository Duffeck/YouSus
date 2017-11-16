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
using yousus.Models;

namespace yousus.Controllers
{
    public class DenunciaController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Denuncia
        public IQueryable<Denuncia> GetDenuncias()
        {
            return db.Denuncias;
        }

        // GET: api/Denuncia/5
        [ResponseType(typeof(Denuncia))]
        public async Task<IHttpActionResult> GetDenuncia(int id)
        {
            Denuncia denuncia = await db.Denuncias.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return Ok(denuncia);
        }

        // PUT: api/Denuncia/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDenuncia(int id, Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denuncia.Id)
            {
                return BadRequest();
            }

            db.Entry(denuncia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaExists(id))
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

        // POST: api/Denuncia
        [ResponseType(typeof(Denuncia))]
        public async Task<IHttpActionResult> PostDenuncia(Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Denuncias.Add(denuncia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = denuncia.Id }, denuncia);
        }

        // DELETE: api/Denuncia/5
        [ResponseType(typeof(Denuncia))]
        public async Task<IHttpActionResult> DeleteDenuncia(int id)
        {
            Denuncia denuncia = await db.Denuncias.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }

            db.Denuncias.Remove(denuncia);
            await db.SaveChangesAsync();

            return Ok(denuncia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DenunciaExists(int id)
        {
            return db.Denuncias.Count(e => e.Id == id) > 0;
        }
    }
}