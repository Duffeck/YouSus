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
    public class TipoController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Tipo
        public IQueryable<Tipo> GetTipoes()
        {
            return db.Tipoes;
        }

        // GET: api/Tipo/5
        [ResponseType(typeof(Tipo))]
        public async Task<IHttpActionResult> GetTipo(int id)
        {
            Tipo tipo = await db.Tipoes.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            return Ok(tipo);
        }

        // PUT: api/Tipo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipo(int id, Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo.Id)
            {
                return BadRequest();
            }

            db.Entry(tipo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        // POST: api/Tipo
        [ResponseType(typeof(Tipo))]
        public async Task<IHttpActionResult> PostTipo(Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipoes.Add(tipo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipo.Id }, tipo);
        }

        // DELETE: api/Tipo/5
        [ResponseType(typeof(Tipo))]
        public async Task<IHttpActionResult> DeleteTipo(int id)
        {
            Tipo tipo = await db.Tipoes.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            db.Tipoes.Remove(tipo);
            await db.SaveChangesAsync();

            return Ok(tipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoExists(int id)
        {
            return db.Tipoes.Count(e => e.Id == id) > 0;
        }
    }
}