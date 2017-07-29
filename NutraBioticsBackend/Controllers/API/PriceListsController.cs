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
    public class PriceListsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PriceLists
        public IQueryable<PriceList> GetPriceLists()
        {
            return db.PriceLists;
        }

        // GET: api/PriceLists/5
        [ResponseType(typeof(PriceList))]
        public async Task<IHttpActionResult> GetPriceList(int id)
        {
            PriceList priceList = await db.PriceLists.FindAsync(id);
            if (priceList == null)
            {
                return NotFound();
            }

            return Ok(priceList);
        }

        // PUT: api/PriceLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPriceList(int id, PriceList priceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceList.PriceListId)
            {
                return BadRequest();
            }

            db.Entry(priceList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceListExists(id))
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

        // POST: api/PriceLists
        [ResponseType(typeof(PriceList))]
        public async Task<IHttpActionResult> PostPriceList(PriceList priceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceLists.Add(priceList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = priceList.PriceListId }, priceList);
        }

        // DELETE: api/PriceLists/5
        [ResponseType(typeof(PriceList))]
        public async Task<IHttpActionResult> DeletePriceList(int id)
        {
            PriceList priceList = await db.PriceLists.FindAsync(id);
            if (priceList == null)
            {
                return NotFound();
            }

            db.PriceLists.Remove(priceList);
            await db.SaveChangesAsync();

            return Ok(priceList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceListExists(int id)
        {
            return db.PriceLists.Count(e => e.PriceListId == id) > 0;
        }
    }
}