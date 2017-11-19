using Newtonsoft.Json;
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
    public class InformativoController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        [HttpGet]
        [ActionName("InformativoAleatorio")]
        public string InformativoAleatorio()
        {
            Informativo informativo;
            //InformativoDao dao = new InformativoDao();
            //informativo = dao.InformativoAleatorio();
            informativo = (Informativo)db.Buscar<Informativo>(p => p.Id > 0).FirstOrDefault();
            if (informativo != null)
            {
                return JsonConvert.SerializeObject(informativo);
            }
            else
            {
                return "";
            }

        }
        /*
        // GET: api/Informativo
        public IQueryable<Informativo> GetInformativoes()
        {
            return db.Informativoes;
        }

        // GET: api/Informativo/5
        [ResponseType(typeof(Informativo))]
        public async Task<IHttpActionResult> GetInformativo(int id)
        {
            Informativo informativo = await db.Informativoes.FindAsync(id);
            if (informativo == null)
            {
                return NotFound();
            }

            return Ok(informativo);
        }

        // PUT: api/Informativo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInformativo(int id, Informativo informativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informativo.Id)
            {
                return BadRequest();
            }

            db.Entry(informativo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformativoExists(id))
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

        // POST: api/Informativo
        [ResponseType(typeof(Informativo))]
        public async Task<IHttpActionResult> PostInformativo(Informativo informativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Informativoes.Add(informativo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = informativo.Id }, informativo);
        }

        // DELETE: api/Informativo/5
        [ResponseType(typeof(Informativo))]
        public async Task<IHttpActionResult> DeleteInformativo(int id)
        {
            Informativo informativo = await db.Informativoes.FindAsync(id);
            if (informativo == null)
            {
                return NotFound();
            }

            db.Informativoes.Remove(informativo);
            await db.SaveChangesAsync();

            return Ok(informativo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformativoExists(int id)
        {
            return db.Informativoes.Count(e => e.Id == id) > 0;
        }
        */
    }
}