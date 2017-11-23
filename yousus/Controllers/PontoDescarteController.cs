using AutoMapper;
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
using yousus.Models.DTO;

namespace yousus.Controllers
{
    public class PontoDescarteController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        private IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        [HttpPost]
        [ActionName("CadastrarPontoDescarte")]
        public bool Inserir(PontoDescarte pontoDescarte)
        {
            //pontoDescarte.Localizacao = localizacao;
            //PontoDescarteDao dao = new PontoDescarteDao();
            if(pontoDescarte.Categoria != null)
            {
                Categoria categoria = db.BuscarPorId<Categoria>(pontoDescarte.Categoria.Id);
                if(categoria != null)
                {
                    pontoDescarte.Categoria = categoria;
                }
            }
            try
            {
                db.Inserir(pontoDescarte);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        [HttpGet]
        [ActionName("ListarPontosDescarte")]
        public string ListarPontosDescarte()
        {
            List<PontoDescarte> pontosDescarte;
            List<PontoDescarteDTO> pontosDescarteDto = new List<PontoDescarteDTO>();
            pontosDescarte = db.ListarTodos<PontoDescarte>();
            if(pontosDescarte.Count() > 0)
            {
                foreach(PontoDescarte ponto in pontosDescarte)
                {
                    pontosDescarteDto.Add(mapper.Map<PontoDescarte, PontoDescarteDTO>(ponto));
                }
                return JsonConvert.SerializeObject(pontosDescarteDto);
            }
            return "";

        }

        [HttpGet]
        [ActionName("ListarPontosPorCategoria")]
        public string ListarPontosDescarteCategoria(int id_categoria)
        {
            List<PontoDescarte> pontosDescarte;
            List<PontoDescarteDTO> pontosDescarteDto = new List<PontoDescarteDTO>();
            if (id_categoria > 0)
            {
                pontosDescarte = db.Buscar<PontoDescarte>(p => p.Categoria.Id == id_categoria);
                if (pontosDescarte.Count() > 0)
                {
                    foreach (PontoDescarte ponto in pontosDescarte)
                    {
                        pontosDescarteDto.Add(mapper.Map<PontoDescarte, PontoDescarteDTO>(ponto));
                    }
                    return JsonConvert.SerializeObject(pontosDescarteDto);
                }
            }
            return "";

        }

        [HttpGet]
        [ActionName("PontoDescarteDetail")]
        public String PontoDescarteDetail(int id)
        {
            //PontoDescarteDao dao = new PontoDescarteDao();

            PontoDescarte ponto = db.BuscarPorId<PontoDescarte>(id);

            return JsonConvert.SerializeObject(ponto);
        }
        /*
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
        */
    }
}