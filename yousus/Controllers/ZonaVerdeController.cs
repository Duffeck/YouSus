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
    public class ZonaVerdeController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/ZonaVerde
        public IQueryable<ZonaVerde> GetZonaVerdes()
        {
            return db.ZonaVerdes;
        }

        // GET: api/ZonaVerde/5
        [ResponseType(typeof(ZonaVerde))]
        public async Task<IHttpActionResult> GetZonaVerde(int id)
        {
            ZonaVerde zonaVerde = await db.ZonaVerdes.FindAsync(id);
            if (zonaVerde == null)
            {
                return NotFound();
            }

            return Ok(zonaVerde);
        }

        // PUT: api/ZonaVerde/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZonaVerde(int id, ZonaVerde zonaVerde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zonaVerde.Id)
            {
                return BadRequest();
            }

            db.Entry(zonaVerde).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaVerdeExists(id))
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

        // POST: api/ZonaVerde
        [ResponseType(typeof(ZonaVerde))]
        public async Task<IHttpActionResult> PostZonaVerde(ZonaVerde zonaVerde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZonaVerdes.Add(zonaVerde);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zonaVerde.Id }, zonaVerde);
        }

        // DELETE: api/ZonaVerde/5
        [ResponseType(typeof(ZonaVerde))]
        public async Task<IHttpActionResult> DeleteZonaVerde(int id)
        {
            ZonaVerde zonaVerde = await db.ZonaVerdes.FindAsync(id);
            if (zonaVerde == null)
            {
                return NotFound();
            }

            db.ZonaVerdes.Remove(zonaVerde);
            await db.SaveChangesAsync();

            return Ok(zonaVerde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZonaVerdeExists(int id)
        {
            return db.ZonaVerdes.Count(e => e.Id == id) > 0;
        }
    }
}