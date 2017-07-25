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
using NutraBioticsBackend.Models;

namespace NutraBioticsBackend.Controllers.API
{
    public class ShipToesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ShipToes
        public IQueryable<ShipTo> GetShipToes()
        {
            return db.ShipToes;
        }

        // GET: api/ShipToes/5
        [ResponseType(typeof(ShipTo))]
        public async Task<IHttpActionResult> GetShipTo(int id)
        {
            ShipTo shipTo = await db.ShipToes.FindAsync(id);
            if (shipTo == null)
            {
                return NotFound();
            }

            return Ok(shipTo);
        }

        // PUT: api/ShipToes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShipTo(int id, ShipTo shipTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipTo.ShipToId)
            {
                return BadRequest();
            }

            db.Entry(shipTo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipToExists(id))
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

        // POST: api/ShipToes
        [ResponseType(typeof(ShipTo))]
        public async Task<IHttpActionResult> PostShipTo(ShipTo shipTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShipToes.Add(shipTo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shipTo.ShipToId }, shipTo);
        }

        // DELETE: api/ShipToes/5
        [ResponseType(typeof(ShipTo))]
        public async Task<IHttpActionResult> DeleteShipTo(int id)
        {
            ShipTo shipTo = await db.ShipToes.FindAsync(id);
            if (shipTo == null)
            {
                return NotFound();
            }

            db.ShipToes.Remove(shipTo);
            await db.SaveChangesAsync();

            return Ok(shipTo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShipToExists(int id)
        {
            return db.ShipToes.Count(e => e.ShipToId == id) > 0;
        }
    }
}