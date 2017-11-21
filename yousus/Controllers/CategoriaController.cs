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
    public class CategoriaController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        private IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        [HttpGet]
        [ActionName("ListarTodasCategorias")]
        public string ListarTodasCategorias()
        {
            List<Categoria> categoriasAux;
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            //categorias = mapper.Map<List<Categoria>, List<CategoriaDTO>>(db.ListarTodos<Categoria>());
            
            categoriasAux = db.ListarTodos<Categoria>();
            foreach(Categoria categoria in categoriasAux)
            {
                categorias.Add(mapper.Map<Categoria, CategoriaDTO>(categoria));
            }
            
            /*
            if(categorias.Count > 0)
            {
                SqlServerDao dao2 = new SqlServerDao();

                foreach(Categoria categoria in categorias)
                {
                    categoria.Origens = dao2.ListarTodos<Origem>();
                    categoria.Periculosidades = dao2.Buscar<Periculosidade>(p => p.Categorias.Contains(categoria));
                    categoria.ComposicoesQuimica = dao2.Buscar<ComposicaoQuimica>(p => p.Categorias.Contains(categoria));
                    categoria.Tipos = dao2.Buscar<Tipo>(p => p.Categorias.Contains(categoria));
                }
            }
            */
            return JsonConvert.SerializeObject(categorias);
        }

        [HttpGet]
        [ActionName("ListarOrigens")]
        public string ListarOrigens([FromUri] Categoria categoria)
        {
            //List<Origem> origens;
            //origens = db.ListarOrigem(categoria);
            List<Origem> origens;
            List<OrigemDTO> origensDto = new List<OrigemDTO>();
            if (categoria.Id != 0)
            {
                origens = db.Buscar<Origem>(o => o.Categorias.Where(c => c.Id == categoria.Id).FirstOrDefault() != null);
            }
            else
            {
                origens = db.ListarTodos<Origem>();
            }
            foreach(Origem origem in origens)
            {
                origensDto.Add(mapper.Map<Origem, OrigemDTO>(origem));
            }
            return JsonConvert.SerializeObject(origensDto);
        }

        [HttpGet]
        [ActionName("ListarPericulosidades")]
        public string ListarPericulosidades([FromUri] Categoria categoria)
        {
            //List<Periculosidade> periculosidades;
            //periculosidades = dao.ListarPericulosidade(categoria);
            List<Periculosidade> periculosidades;
            List<PericulosidadeDTO> periculosidadesDto = new List<PericulosidadeDTO>();
            if (categoria.Id != 0)
            {
                periculosidades = db.Buscar<Periculosidade>(o => o.Categorias.Where(c => c.Id == categoria.Id) != null);
            }
            else
            {
                periculosidades = db.ListarTodos<Periculosidade>();
            }
            foreach(Periculosidade periculosidade in periculosidades){
                periculosidadesDto.Add(mapper.Map<Periculosidade, PericulosidadeDTO>(periculosidade));
            }
            return JsonConvert.SerializeObject(periculosidadesDto);
        }

        [HttpGet]
        [ActionName("ListarTipos")]
        public string ListarTipos([FromUri] Categoria categoria)
        {
            //List<Tipo> tipos;
            //CategoriaDao dao = new CategoriaDao();
            //tipos = dao.ListarTipo(categoria);
            List<Tipo> tipos;
            List<TipoDTO> tiposDto = new List<TipoDTO>();
            if (categoria.Id != 0)
            {
                tipos = db.Buscar<Tipo>(o => o.Categorias.Where(c => c.Id == categoria.Id) != null);
            }
            else
            {
                tipos = db.ListarTodos<Tipo>();
            }
            foreach(Tipo tipo in tipos)
            {
                tiposDto.Add(mapper.Map<Tipo, TipoDTO>(tipo));
            }
            return JsonConvert.SerializeObject(tipos);
        }
        [HttpGet]
        [ActionName("ListarComposicaoQuimica")]
        public string ListarComposicaoQuimica([FromUri] Categoria categoria)
        {
            //List<ComposicaoQuimica> compQuimica;
            //CategoriaDao dao = new CategoriaDao();
            //compQuimica = dao.ListarComposicaoQuimica(categoria);
            List<ComposicaoQuimica> compQuimica;
            List<ComposicaoQuimicaDTO> compQuimicaDto = new List<ComposicaoQuimicaDTO>();
            if (categoria.Id != 0)
            {
                compQuimica = db.Buscar<ComposicaoQuimica>(o => o.Categorias.Where(c => c.Id == categoria.Id) != null);
            }
            else
            {
                compQuimica = db.ListarTodos<ComposicaoQuimica>();
            }
            foreach(ComposicaoQuimica composicao in compQuimica)
            {
                compQuimicaDto.Add(mapper.Map<ComposicaoQuimica, ComposicaoQuimicaDTO>(composicao));
            }
            return JsonConvert.SerializeObject(compQuimica);
        }
        [HttpPost]
        [ActionName("SalvarCategoria")]
        public int SalvarCategoria([FromBody] Categoria categoria)
        {
            if (categoria != null)
            {
                List<Origem> origens = new List<Origem>();
                foreach (Origem origem in categoria.Origens)
                {
                    origens.Add(db.BuscarPorId<Origem>(origem.Id));
                }
                categoria.Origens = origens;

                List<ComposicaoQuimica> composicoesQuimicas = new List<ComposicaoQuimica>();
                foreach (ComposicaoQuimica composicao in categoria.ComposicoesQuimica)
                {
                    composicoesQuimicas.Add(db.BuscarPorId<ComposicaoQuimica>(composicao.Id));
                }
                categoria.ComposicoesQuimica = composicoesQuimicas;

                List<Periculosidade> periculosidades = new List<Periculosidade>();
                foreach (Periculosidade periculosidade in categoria.Periculosidades)
                {
                    periculosidades.Add(db.BuscarPorId<Periculosidade>(periculosidade.Id));
                }
                categoria.Periculosidades = periculosidades;

                List<Tipo> tipos = new List<Tipo>();
                foreach (Tipo tipo in categoria.Tipos)
                {
                    tipos.Add(db.BuscarPorId<Tipo>(tipo.Id));
                }
                categoria.Tipos = tipos;
                db.Inserir(categoria);
                return categoria.Id;

            }
            return 0;
        }
        /*
        // GET: api/Categoria
        public IQueryable<Categoria> GetCategorias()
        {
            return db.Categorias;
        }

        // GET: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> GetCategoria(int id)
        {
            Categoria categoria = await db.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categoria/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categoria
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorias.Add(categoria);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> DeleteCategoria(int id)
        {
            Categoria categoria = await db.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categorias.Remove(categoria);
            await db.SaveChangesAsync();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.Categorias.Count(e => e.Id == id) > 0;
        }
        */
    }
}