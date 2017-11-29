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
    public class UsuariosController : ApiController
    {
        private YouSusContext db = new YouSusContext();
        private IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        /*
        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }
        */
        //[ResponseType(typeof(Usuario))]
        [HttpPost]
        [ActionName("EfetuarLogin")]
        //public async Task<IHttpActionResult> LoginUsuario(Usuario usuario)
        public string LoginUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return "";
            }

            //Usuario user = db.Usuarios.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).FirstOrDefault();
            Usuario user = db.Buscar<Usuario>(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)).FirstOrDefault();

            //db.Usuarios.Add(usuario);
            //await db.SaveChangesAsync();
            if(user != null) {
                UsuarioDTO userDTO = new UsuarioDTO();
                userDTO = mapper.Map<Usuario, UsuarioDTO>(usuario);
                return JsonConvert.SerializeObject(userDTO);
            } else {
                return "";
            }
            //return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
   
        }

        [HttpPost]
        [ActionName("CadastrarUsuario")]
        public string CadastrarUsuario([FromUri]Usuario usuario)
        {
            Usuario user = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            try
            {
                db.Inserir<Usuario>(user);
                return "Cadastro efetuado";
            }
            catch (Exception e)
            {
                Console.Write(e);
                return "Ocorreu algum problema, tente novamente em alguns minutos";
            }
        }
        /*
        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
        */
    }
}