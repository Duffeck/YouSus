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
    public class DataRotaController : ApiController
    {
        private YouSusContext db = new YouSusContext();

        // GET: api/DataRota
        public IQueryable<DataRota> GetDataRotas()
        {
            return db.DataRotas;
        }

        // GET: api/DataRota/5
        [ResponseType(typeof(DataRota))]
        public async Task<IHttpActionResult> GetDataRota(int id)
        {
            DataRota dataRota = await db.DataRotas.FindAsync(id);
            if (dataRota == null)
            {
                return NotFound();
            }

            return Ok(dataRota);
        }

        // PUT: api/DataRota/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDataRota(int id, DataRota dataRota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataRota.Id)
            {
                return BadRequest();
            }

            db.Entry(dataRota).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataRotaExists(id))
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

        // POST: api/DataRota
        [ResponseType(typeof(DataRota))]
        public async Task<IHttpActionResult> PostDataRota(DataRota dataRota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DataRotas.Add(dataRota);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dataRota.Id }, dataRota);
        }

        // DELETE: api/DataRota/5
        [ResponseType(typeof(DataRota))]
        public async Task<IHttpActionResult> DeleteDataRota(int id)
        {
            DataRota dataRota = await db.DataRotas.FindAsync(id);
            if (dataRota == null)
            {
                return NotFound();
            }

            db.DataRotas.Remove(dataRota);
            await db.SaveChangesAsync();

            return Ok(dataRota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataRotaExists(int id)
        {
            return db.DataRotas.Count(e => e.Id == id) > 0;
        }
    }
}