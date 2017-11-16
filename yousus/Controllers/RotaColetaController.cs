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
    public class RotaColetaController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/RotaColeta
        public IQueryable<RotaColeta> GetRotaColetas()
        {
            return db.RotaColetas;
        }

        // GET: api/RotaColeta/5
        [ResponseType(typeof(RotaColeta))]
        public async Task<IHttpActionResult> GetRotaColeta(int id)
        {
            RotaColeta rotaColeta = await db.RotaColetas.FindAsync(id);
            if (rotaColeta == null)
            {
                return NotFound();
            }

            return Ok(rotaColeta);
        }

        // PUT: api/RotaColeta/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRotaColeta(int id, RotaColeta rotaColeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rotaColeta.Id)
            {
                return BadRequest();
            }

            db.Entry(rotaColeta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaColetaExists(id))
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

        // POST: api/RotaColeta
        [ResponseType(typeof(RotaColeta))]
        public async Task<IHttpActionResult> PostRotaColeta(RotaColeta rotaColeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RotaColetas.Add(rotaColeta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rotaColeta.Id }, rotaColeta);
        }

        // DELETE: api/RotaColeta/5
        [ResponseType(typeof(RotaColeta))]
        public async Task<IHttpActionResult> DeleteRotaColeta(int id)
        {
            RotaColeta rotaColeta = await db.RotaColetas.FindAsync(id);
            if (rotaColeta == null)
            {
                return NotFound();
            }

            db.RotaColetas.Remove(rotaColeta);
            await db.SaveChangesAsync();

            return Ok(rotaColeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RotaColetaExists(int id)
        {
            return db.RotaColetas.Count(e => e.Id == id) > 0;
        }
    }
}