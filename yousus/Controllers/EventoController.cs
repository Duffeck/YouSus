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
    public class EventoController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        [HttpGet]
        [ActionName("ListarEventos")]
        public string ListarEventos(int id_evento)
        {
            List<Evento> eventos;
            eventos = db.ListarTodos<Evento>();
            if (eventos.Count > 0)
            {
                foreach (Evento evento in eventos)
                {
                    evento.Periodos = db.Buscar<Periodo>(p => p.Evento.Id == evento.Id);
                }
            }
            return JsonConvert.SerializeObject(eventos);
        }

        [HttpPost]
        [ActionName("CadastrarEvento")]
        public int Inserir(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            try{
                db.Inserir(evento);
                return evento.Id;
            }catch(Exception e)
            {
                return 0;
            }
    }
        /*
        // GET: api/Evento
        public IQueryable<Evento> GetEventoes()
        {
            return db.Eventoes;
        }

        // GET: api/Evento/5
        [ResponseType(typeof(Evento))]
        public async Task<IHttpActionResult> GetEvento(int id)
        {
            Evento evento = await db.Eventoes.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/Evento/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvento(int id, Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.Id)
            {
                return BadRequest();
            }

            db.Entry(evento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Evento
        [ResponseType(typeof(Evento))]
        public async Task<IHttpActionResult> PostEvento(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Eventoes.Add(evento);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = evento.Id }, evento);
        }

        // DELETE: api/Evento/5
        [ResponseType(typeof(Evento))]
        public async Task<IHttpActionResult> DeleteEvento(int id)
        {
            Evento evento = await db.Eventoes.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            db.Eventoes.Remove(evento);
            await db.SaveChangesAsync();

            return Ok(evento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoExists(int id)
        {
            return db.Eventoes.Count(e => e.Id == id) > 0;
        }
        */
    }
}