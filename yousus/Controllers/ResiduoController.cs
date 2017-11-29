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
    public class ResiduoController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        private IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        [HttpPost]
        [ActionName("SalvarResiduo")]
        public int Inserir(Residuo residuo, [FromUri]int[] id_fotos)
        {
            if (residuo != null)
            {
                //residuo.Categoria = new Categoria();
                /*
                if (id_fotos.Length > 0)
                {
                    foreach (int id_foto in id_fotos)
                    {
                        Foto foto = db.BuscarPorId<Foto>(id_foto);
                        if (foto != null)
                        {
                            residuo.Fotos.Add(foto);
                        }
                    }
                }*/
                if (residuo.Fotos.Count > 0)
                {
                    List<Foto> fotos_aux = new List<Foto>();
                    foreach (Foto foto in residuo.Fotos)
                    {
                        Foto foto_aux = db.BuscarPorId<Foto>(foto.Id);
                        if (foto_aux != null)
                        {
                            fotos_aux.Add(foto_aux);
                        }
                    }
                    residuo.Fotos = fotos_aux;
                }
                if(residuo.Usuario != null)
                {
                    Usuario usuario = db.BuscarPorId<Usuario>(residuo.Usuario.Id);
                    if(usuario != null)
                    {
                        residuo.Usuario = usuario;
                    }
                    else
                    {
                        residuo.Usuario = null;
                    }
                }
                //ResiduoDao dao = new ResiduoDao();
                try
                {
                    if(residuo.Categoria != null)
                    {
                        var categoria = db.BuscarPorId<Categoria>(residuo.Categoria.Id);
                        if (categoria != null)
                        {
                            residuo.Categoria = categoria;
                        }
                        else
                        {
                            residuo.Categoria = null;
                        }
                    }
                    db.Inserir(residuo);
                    return residuo.Id;
                }catch(Exception e)
                {
                    return 0;
                }
            }
            return 0;
        }

        [HttpGet]
        [ActionName("ListarResiduos")]
        public string ListarResiduos([FromUri] int ultimoId)
        {

            //SqlServerDao dao = new SqlServerDao();
            List<Residuo> residuos;
            List<ResiduoDTO> residuosDto = new List<ResiduoDTO>();
            if (ultimoId > 0)
            {
                residuos = db.BuscarComPaginacao<Residuo>(p => p.Id > 0, 3, ultimoId);
            }
            else
            {
                residuos = (List<Residuo>)db.ListarTodos<Residuo>().Take(3).ToList();
            }

            if (residuos != null)
            {
                foreach(Residuo residuo in residuos)
                {
                    residuosDto.Add(mapper.Map<Residuo, ResiduoDTO>(residuo));
                }
                return JsonConvert.SerializeObject(residuosDto);
            }
            else
            {
                return "";
            }
        }

        [HttpGet]
        [ActionName("ListarResiduosPorNome")]
        public string ListarResiduosPorNome([FromUri] string nome)
        {

            //SqlServerDao dao = new SqlServerDao();
            List<Residuo> residuos;
            List<ResiduoDTO> residuosDto = new List<ResiduoDTO>();
            if (nome != null && nome.Length > 0)
            {
                residuos = db.Buscar<Residuo>(p => p.Nome.ToLower().Contains(nome.ToLower()));
            }
            else
            {
                return "";
            }

            if (residuos != null)
            {
                foreach (Residuo residuo in residuos)
                {
                    residuosDto.Add(mapper.Map<Residuo, ResiduoDTO>(residuo));
                }
                return JsonConvert.SerializeObject(residuosDto);
            }
            else
            {
                return "";
            }
        }
        /*
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
        */
    }
}