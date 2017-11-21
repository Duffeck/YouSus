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
    public class LocalizacaoController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        private IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        /*
        // GET: api/Localizacao
        public IQueryable<Localizacao> GetLocalizacaos()
        {
            return db.Localizacaos;
        }

        // GET: api/Localizacao/5
        [ResponseType(typeof(Localizacao))]
        public async Task<IHttpActionResult> GetLocalizacao(int id)
        {
            Localizacao localizacao = await db.Localizacaos.FindAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }

            return Ok(localizacao);
        }

        // PUT: api/Localizacao/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocalizacao(int id, Localizacao localizacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localizacao.Id)
            {
                return BadRequest();
            }

            db.Entry(localizacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalizacaoExists(id))
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

        // POST: api/Localizacao
        [ResponseType(typeof(Localizacao))]
        public async Task<IHttpActionResult> PostLocalizacao(Localizacao localizacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Localizacaos.Add(localizacao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = localizacao.Id }, localizacao);
        }

        // DELETE: api/Localizacao/5
        [ResponseType(typeof(Localizacao))]
        public async Task<IHttpActionResult> DeleteLocalizacao(int id)
        {
            Localizacao localizacao = await db.Localizacaos.FindAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }

            db.Localizacaos.Remove(localizacao);
            await db.SaveChangesAsync();

            return Ok(localizacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocalizacaoExists(int id)
        {
            return db.Localizacaos.Count(e => e.Id == id) > 0;
        }
        */

        [HttpPost]
        [ActionName("ListarPorCategoria")]
        public string ListarPorCategoria(int id_categoria)
        {
            Categoria categoria = db.BuscarPorId<Categoria>(id_categoria);
            List<PontoDescarte> pontos = db.Buscar<PontoDescarte>(p => p.Categoria.Id == categoria.Id);
            List<LocalizacaoDTO> localizacoes = new List<LocalizacaoDTO>();
            foreach(PontoDescarte ponto in pontos)
            {
                if(ponto.Localizacao != null)
                {
                    localizacoes.Add(mapper.Map<Localizacao, LocalizacaoDTO>(ponto.Localizacao));
                }
            }
            return JsonConvert.SerializeObject(localizacoes);
        }
    }
}