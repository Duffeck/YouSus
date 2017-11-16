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
    public class AlertaController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        /*[HttpGet]
        [ActionName("CadastrarAlerta")]
        public bool Inserir([FromUri]ZonaVerde zonaVerde, [FromUri]Localizacao localizacao)
        {
            zonaVerde.Localizacao = localizacao;

            ZonaVerdeDao zonaVerdeDao = new ZonaVerdeDao();
            var test = zonaVerdeDao.Inserir(zonaVerde);

            return true;
        }*/

        [HttpGet]
        [ActionName("ListarAlertas")]
        public String ListarAlertas()
        {
            List<Alerta> alertas;
            //AlertaDao dao = new AlertaDao();

            alertas = db.ListarTodos<Alerta>();

            return JsonConvert.SerializeObject(alertas);

        }
        /*
        // GET: api/Alerta
        public IQueryable<Alerta> GetAlertas()
        {
            return db.Alertas;
        }

        // GET: api/Alerta/5
        [ResponseType(typeof(Alerta))]
        public async Task<IHttpActionResult> GetAlerta(int id)
        {
            Alerta alerta = await db.Alertas.FindAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            return Ok(alerta);
        }

        // PUT: api/Alerta/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlerta(int id, Alerta alerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alerta.Id)
            {
                return BadRequest();
            }

            db.Entry(alerta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaExists(id))
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

        // POST: api/Alerta
        [ResponseType(typeof(Alerta))]
        public async Task<IHttpActionResult> PostAlerta(Alerta alerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alertas.Add(alerta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alerta.Id }, alerta);
        }

        // DELETE: api/Alerta/5
        [ResponseType(typeof(Alerta))]
        public async Task<IHttpActionResult> DeleteAlerta(int id)
        {
            Alerta alerta = await db.Alertas.FindAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            db.Alertas.Remove(alerta);
            await db.SaveChangesAsync();

            return Ok(alerta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertaExists(int id)
        {
            return db.Alertas.Count(e => e.Id == id) > 0;
        }
        */
    }
}