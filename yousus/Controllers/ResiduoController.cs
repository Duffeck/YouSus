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
    public class ResiduoController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Residuo
        public IQueryable<Residuo> GetResiduos()
        {
            return db.Residuos;
        }

        // GET: api/Residuo/5
        [ResponseType(typeof(Residuo))]
        public async Task<IHttpActionResult> GetResiduo(int id)
        {
            Residuo residuo = await db.Residuos.FindAsync(id);
            if (residuo == null)
            {
                return NotFound();
            }

            return Ok(residuo);
        }

        // PUT: api/Residuo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResiduo(int id, Residuo residuo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residuo.Id)
            {
                return BadRequest();
            }

            db.Entry(residuo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResiduoExists(id))
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

        // POST: api/Residuo
        [ResponseType(typeof(Residuo))]
        public async Task<IHttpActionResult> PostResiduo(Residuo residuo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residuos.Add(residuo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = residuo.Id }, residuo);
        }

        // DELETE: api/Residuo/5
        [ResponseType(typeof(Residuo))]
        public async Task<IHttpActionResult> DeleteResiduo(int id)
        {
            Residuo residuo = await db.Residuos.FindAsync(id);
            if (residuo == null)
            {
                return NotFound();
            }

            db.Residuos.Remove(residuo);
            await db.SaveChangesAsync();

            return Ok(residuo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResiduoExists(int id)
        {
            return db.Residuos.Count(e => e.Id == id) > 0;
        }
    }
}