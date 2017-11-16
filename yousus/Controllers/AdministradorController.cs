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
    public class AdministradorController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/Administrador
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Administrador/5
        [ResponseType(typeof(Administrador))]
        public async Task<IHttpActionResult> GetAdministrador(int id)
        {
            Administrador administrador = await db.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        // PUT: api/Administrador/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrador.Id)
            {
                return BadRequest();
            }

            db.Entry(administrador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administrador
        [ResponseType(typeof(Administrador))]
        public async Task<IHttpActionResult> PostAdministrador(Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(administrador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administrador.Id }, administrador);
        }

        // DELETE: api/Administrador/5
        [ResponseType(typeof(Administrador))]
        public async Task<IHttpActionResult> DeleteAdministrador(int id)
        {
            Administrador administrador = await db.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(administrador);
            await db.SaveChangesAsync();

            return Ok(administrador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}