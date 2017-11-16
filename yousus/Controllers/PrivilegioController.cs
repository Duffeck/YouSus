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
    public class PrivilegioController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Privilegio
        public IQueryable<Privilegio> GetPrivilegios()
        {
            return db.Privilegios;
        }

        // GET: api/Privilegio/5
        [ResponseType(typeof(Privilegio))]
        public async Task<IHttpActionResult> GetPrivilegio(int id)
        {
            Privilegio privilegio = await db.Privilegios.FindAsync(id);
            if (privilegio == null)
            {
                return NotFound();
            }

            return Ok(privilegio);
        }

        // PUT: api/Privilegio/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrivilegio(int id, Privilegio privilegio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != privilegio.Id)
            {
                return BadRequest();
            }

            db.Entry(privilegio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivilegioExists(id))
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

        // POST: api/Privilegio
        [ResponseType(typeof(Privilegio))]
        public async Task<IHttpActionResult> PostPrivilegio(Privilegio privilegio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Privilegios.Add(privilegio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = privilegio.Id }, privilegio);
        }

        // DELETE: api/Privilegio/5
        [ResponseType(typeof(Privilegio))]
        public async Task<IHttpActionResult> DeletePrivilegio(int id)
        {
            Privilegio privilegio = await db.Privilegios.FindAsync(id);
            if (privilegio == null)
            {
                return NotFound();
            }

            db.Privilegios.Remove(privilegio);
            await db.SaveChangesAsync();

            return Ok(privilegio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrivilegioExists(int id)
        {
            return db.Privilegios.Count(e => e.Id == id) > 0;
        }
    }
}