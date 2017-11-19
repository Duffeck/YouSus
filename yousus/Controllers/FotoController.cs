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
    public class FotoController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        [HttpGet]
        [ActionName("SalvarFoto")]
        public int Inserir([FromUri]Foto foto)
        {
            if (foto != null)
            {
                try
                {
                    db.Inserir(foto);
                    return foto.Id;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            return 0;
        }
        /*

        // GET: api/Foto
        public IQueryable<Foto> GetFotoes()
        {
            return db.Fotoes;
        }

        // GET: api/Foto/5
        [ResponseType(typeof(Foto))]
        public async Task<IHttpActionResult> GetFoto(int id)
        {
            Foto foto = await db.Fotoes.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }

            return Ok(foto);
        }

        // PUT: api/Foto/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFoto(int id, Foto foto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foto.Id)
            {
                return BadRequest();
            }

            db.Entry(foto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoExists(id))
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

        // POST: api/Foto
        [ResponseType(typeof(Foto))]
        public async Task<IHttpActionResult> PostFoto(Foto foto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fotoes.Add(foto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = foto.Id }, foto);
        }

        // DELETE: api/Foto/5
        [ResponseType(typeof(Foto))]
        public async Task<IHttpActionResult> DeleteFoto(int id)
        {
            Foto foto = await db.Fotoes.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }

            db.Fotoes.Remove(foto);
            await db.SaveChangesAsync();

            return Ok(foto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FotoExists(int id)
        {
            return db.Fotoes.Count(e => e.Id == id) > 0;
        }
        */
    }
}