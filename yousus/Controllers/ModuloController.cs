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
    public class ModuloController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Modulo
        public IQueryable<Modulo> GetModuloes()
        {
            return db.Moduloes;
        }

        // GET: api/Modulo/5
        [ResponseType(typeof(Modulo))]
        public async Task<IHttpActionResult> GetModulo(int id)
        {
            Modulo modulo = await db.Moduloes.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            return Ok(modulo);
        }

        // PUT: api/Modulo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModulo(int id, Modulo modulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modulo.Id)
            {
                return BadRequest();
            }

            db.Entry(modulo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(id))
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

        // POST: api/Modulo
        [ResponseType(typeof(Modulo))]
        public async Task<IHttpActionResult> PostModulo(Modulo modulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Moduloes.Add(modulo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = modulo.Id }, modulo);
        }

        // DELETE: api/Modulo/5
        [ResponseType(typeof(Modulo))]
        public async Task<IHttpActionResult> DeleteModulo(int id)
        {
            Modulo modulo = await db.Moduloes.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            db.Moduloes.Remove(modulo);
            await db.SaveChangesAsync();

            return Ok(modulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuloExists(int id)
        {
            return db.Moduloes.Count(e => e.Id == id) > 0;
        }
    }
}