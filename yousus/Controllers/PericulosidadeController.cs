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
    public class PericulosidadeController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Periculosidade
        public IQueryable<Periculosidade> GetPericulosidades()
        {
            return db.Periculosidades;
        }

        // GET: api/Periculosidade/5
        [ResponseType(typeof(Periculosidade))]
        public async Task<IHttpActionResult> GetPericulosidade(int id)
        {
            Periculosidade periculosidade = await db.Periculosidades.FindAsync(id);
            if (periculosidade == null)
            {
                return NotFound();
            }

            return Ok(periculosidade);
        }

        // PUT: api/Periculosidade/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPericulosidade(int id, Periculosidade periculosidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periculosidade.Id)
            {
                return BadRequest();
            }

            db.Entry(periculosidade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PericulosidadeExists(id))
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

        // POST: api/Periculosidade
        [ResponseType(typeof(Periculosidade))]
        public async Task<IHttpActionResult> PostPericulosidade(Periculosidade periculosidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Periculosidades.Add(periculosidade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = periculosidade.Id }, periculosidade);
        }

        // DELETE: api/Periculosidade/5
        [ResponseType(typeof(Periculosidade))]
        public async Task<IHttpActionResult> DeletePericulosidade(int id)
        {
            Periculosidade periculosidade = await db.Periculosidades.FindAsync(id);
            if (periculosidade == null)
            {
                return NotFound();
            }

            db.Periculosidades.Remove(periculosidade);
            await db.SaveChangesAsync();

            return Ok(periculosidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PericulosidadeExists(int id)
        {
            return db.Periculosidades.Count(e => e.Id == id) > 0;
        }
    }
}