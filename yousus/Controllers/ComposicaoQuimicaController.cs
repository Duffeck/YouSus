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
    public class ComposicaoQuimicaController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/ComposicaoQuimica
        public IQueryable<ComposicaoQuimica> GetComposicaoQuimicas()
        {
            return db.ComposicaoQuimicas;
        }

        // GET: api/ComposicaoQuimica/5
        [ResponseType(typeof(ComposicaoQuimica))]
        public async Task<IHttpActionResult> GetComposicaoQuimica(int id)
        {
            ComposicaoQuimica composicaoQuimica = await db.ComposicaoQuimicas.FindAsync(id);
            if (composicaoQuimica == null)
            {
                return NotFound();
            }

            return Ok(composicaoQuimica);
        }

        // PUT: api/ComposicaoQuimica/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComposicaoQuimica(int id, ComposicaoQuimica composicaoQuimica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != composicaoQuimica.Id)
            {
                return BadRequest();
            }

            db.Entry(composicaoQuimica).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComposicaoQuimicaExists(id))
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

        // POST: api/ComposicaoQuimica
        [ResponseType(typeof(ComposicaoQuimica))]
        public async Task<IHttpActionResult> PostComposicaoQuimica(ComposicaoQuimica composicaoQuimica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComposicaoQuimicas.Add(composicaoQuimica);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = composicaoQuimica.Id }, composicaoQuimica);
        }

        // DELETE: api/ComposicaoQuimica/5
        [ResponseType(typeof(ComposicaoQuimica))]
        public async Task<IHttpActionResult> DeleteComposicaoQuimica(int id)
        {
            ComposicaoQuimica composicaoQuimica = await db.ComposicaoQuimicas.FindAsync(id);
            if (composicaoQuimica == null)
            {
                return NotFound();
            }

            db.ComposicaoQuimicas.Remove(composicaoQuimica);
            await db.SaveChangesAsync();

            return Ok(composicaoQuimica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComposicaoQuimicaExists(int id)
        {
            return db.ComposicaoQuimicas.Count(e => e.Id == id) > 0;
        }
    }
}