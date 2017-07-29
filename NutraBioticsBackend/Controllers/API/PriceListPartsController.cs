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
    public class PriceListPartsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PriceListParts
        public IQueryable<PriceListPart> GetPriceListParts()
        {
            return db.PriceListParts;
        }

        // GET: api/PriceListParts/5
        [ResponseType(typeof(PriceListPart))]
        public async Task<IHttpActionResult> GetPriceListPart(int id)
        {
            PriceListPart priceListPart = await db.PriceListParts.FindAsync(id);
            if (priceListPart == null)
            {
                return NotFound();
            }

            return Ok(priceListPart);
        }

        // PUT: api/PriceListParts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPriceListPart(int id, PriceListPart priceListPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceListPart.PriceListPartId)
            {
                return BadRequest();
            }

            db.Entry(priceListPart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceListPartExists(id))
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

        // POST: api/PriceListParts
        [ResponseType(typeof(PriceListPart))]
        public async Task<IHttpActionResult> PostPriceListPart(PriceListPart priceListPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceListParts.Add(priceListPart);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = priceListPart.PriceListPartId }, priceListPart);
        }

        // DELETE: api/PriceListParts/5
        [ResponseType(typeof(PriceListPart))]
        public async Task<IHttpActionResult> DeletePriceListPart(int id)
        {
            PriceListPart priceListPart = await db.PriceListParts.FindAsync(id);
            if (priceListPart == null)
            {
                return NotFound();
            }

            db.PriceListParts.Remove(priceListPart);
            await db.SaveChangesAsync();

            return Ok(priceListPart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceListPartExists(int id)
        {
            return db.PriceListParts.Count(e => e.PriceListPartId == id) > 0;
        }
    }
}