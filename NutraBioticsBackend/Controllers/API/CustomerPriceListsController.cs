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
    public class CustomerPriceListsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CustomerPriceLists
        public IQueryable<CustomerPriceList> GetCustomerPriceLists()
        {
            return db.CustomerPriceLists;
        }

        // GET: api/CustomerPriceLists/5
        [ResponseType(typeof(CustomerPriceList))]
        public async Task<IHttpActionResult> GetCustomerPriceList(int id)
        {
            CustomerPriceList customerPriceList = await db.CustomerPriceLists.FindAsync(id);
            if (customerPriceList == null)
            {
                return NotFound();
            }

            return Ok(customerPriceList);
        }

        // PUT: api/CustomerPriceLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerPriceList(int id, CustomerPriceList customerPriceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerPriceList.CustomerPriceListId)
            {
                return BadRequest();
            }

            db.Entry(customerPriceList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerPriceListExists(id))
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

        // POST: api/CustomerPriceLists
        [ResponseType(typeof(CustomerPriceList))]
        public async Task<IHttpActionResult> PostCustomerPriceList(CustomerPriceList customerPriceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerPriceLists.Add(customerPriceList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerPriceList.CustomerPriceListId }, customerPriceList);
        }

        // DELETE: api/CustomerPriceLists/5
        [ResponseType(typeof(CustomerPriceList))]
        public async Task<IHttpActionResult> DeleteCustomerPriceList(int id)
        {
            CustomerPriceList customerPriceList = await db.CustomerPriceLists.FindAsync(id);
            if (customerPriceList == null)
            {
                return NotFound();
            }

            db.CustomerPriceLists.Remove(customerPriceList);
            await db.SaveChangesAsync();

            return Ok(customerPriceList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerPriceListExists(int id)
        {
            return db.CustomerPriceLists.Count(e => e.CustomerPriceListId == id) > 0;
        }
    }
}