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
    public class PontoDescarteController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/PontoDescarte
        public IQueryable<PontoDescarte> GetPontoDescartes()
        {
            return db.PontoDescartes;
        }

        // GET: api/PontoDescarte/5
        [ResponseType(typeof(PontoDescarte))]
        public async Task<IHttpActionResult> GetPontoDescarte(int id)
        {
            PontoDescarte pontoDescarte = await db.PontoDescartes.FindAsync(id);
            if (pontoDescarte == null)
            {
                return NotFound();
            }

            return Ok(pontoDescarte);
        }

        // PUT: api/PontoDescarte/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPontoDescarte(int id, PontoDescarte pontoDescarte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pontoDescarte.Id)
            {
                return BadRequest();
            }

            db.Entry(pontoDescarte).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontoDescarteExists(id))
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

        // POST: api/PontoDescarte
        [ResponseType(typeof(PontoDescarte))]
        public async Task<IHttpActionResult> PostPontoDescarte(PontoDescarte pontoDescarte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PontoDescartes.Add(pontoDescarte);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pontoDescarte.Id }, pontoDescarte);
        }

        // DELETE: api/PontoDescarte/5
        [ResponseType(typeof(PontoDescarte))]
        public async Task<IHttpActionResult> DeletePontoDescarte(int id)
        {
            PontoDescarte pontoDescarte = await db.PontoDescartes.FindAsync(id);
            if (pontoDescarte == null)
            {
                return NotFound();
            }

            db.PontoDescartes.Remove(pontoDescarte);
            await db.SaveChangesAsync();

            return Ok(pontoDescarte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PontoDescarteExists(int id)
        {
            return db.PontoDescartes.Count(e => e.Id == id) > 0;
        }
    }
}