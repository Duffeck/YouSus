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
    public class OrigemController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Origem
        public IQueryable<Origem> GetOrigems()
        {
            return db.Origems;
        }

        // GET: api/Origem/5
        [ResponseType(typeof(Origem))]
        public async Task<IHttpActionResult> GetOrigem(int id)
        {
            Origem origem = await db.Origems.FindAsync(id);
            if (origem == null)
            {
                return NotFound();
            }

            return Ok(origem);
        }

        // PUT: api/Origem/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrigem(int id, Origem origem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != origem.Id)
            {
                return BadRequest();
            }

            db.Entry(origem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigemExists(id))
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

        // POST: api/Origem
        [ResponseType(typeof(Origem))]
        public async Task<IHttpActionResult> PostOrigem(Origem origem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Origems.Add(origem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = origem.Id }, origem);
        }

        // DELETE: api/Origem/5
        [ResponseType(typeof(Origem))]
        public async Task<IHttpActionResult> DeleteOrigem(int id)
        {
            Origem origem = await db.Origems.FindAsync(id);
            if (origem == null)
            {
                return NotFound();
            }

            db.Origems.Remove(origem);
            await db.SaveChangesAsync();

            return Ok(origem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrigemExists(int id)
        {
            return db.Origems.Count(e => e.Id == id) > 0;
        }
    }
}