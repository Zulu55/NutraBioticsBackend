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
using System.Data.Entity.Validation;

namespace NutraBioticsBackend.Controllers.API
{
    public class OrderHeadersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/OrderHeaders
        public IQueryable<OrderHeader> GetOrderHeaders()
        {
            return db.OrderHeaders;
        }

        // GET: api/OrderHeaders/5
        [ResponseType(typeof(OrderHeader))]
        public async Task<IHttpActionResult> GetOrderHeader(int id)
        {
            OrderHeader orderHeader = await db.OrderHeaders.FindAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return Ok(orderHeader);
        }

        // PUT: api/OrderHeaders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderHeader(int id, OrderHeader orderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderHeader.SalesOrderHeaderId)
            {
                return BadRequest();
            }

            db.Entry(orderHeader).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderHeaderExists(id))
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

        // POST: api/OrderHeaders
        [ResponseType(typeof(OrderHeader))]
        public async Task<IHttpActionResult> PostOrderHeader(List<OrderHeaderSync> list)
        {
            using (var transaccion = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var order in list)
                    {
                        var orderHeader = new OrderHeader
                        {
                             ContactId = order.ContactId,
                             CreditHold = order.CreditHold,
                             CustomerId = order.CustomerId,
                             Date = order.Date,
                             SalesCategory = order.SalesCategory,
                             Observations = order.Observations,
                             ShipToId = order.ShipToId,
                             TermsCode = order.TermsCode,
                             UserId = order.UserId,
                        };

                        db.OrderHeaders.Add(orderHeader);
                        await db.SaveChangesAsync();

                        foreach (var detail in order.OrderDetails)
                        {
                            var orderDetail = new OrderDetail
                            {
                                OrderLine = detail.OrderLine,
                                OrderQty = detail.OrderQty,
                                PartId = detail.PartId,
                                PartNum = detail.PartNum,
                                PriceListPartId = detail.PriceListPartId,
                                SalesOrderHeaderId = orderHeader.SalesOrderHeaderId,
                                TaxAmt = detail.TaxAmt,
                                UnitPrice = detail.UnitPrice,
                            };

                            db.OrderDetails.Add(orderDetail);
                        }
                    }

                    await db.SaveChangesAsync();
                    transaccion.Commit();
                    return Ok(true);
                }
                catch (DbEntityValidationException e)
                {
                    var message = string.Empty;
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        message += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following " +
                            "validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            message += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    transaccion.Rollback();
                    return BadRequest(message);
                }                catch (Exception ex)
                {
                    transaccion.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }

        // DELETE: api/OrderHeaders/5
        [ResponseType(typeof(OrderHeader))]
        public async Task<IHttpActionResult> DeleteOrderHeader(int id)
        {
            OrderHeader orderHeader = await db.OrderHeaders.FindAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            db.OrderHeaders.Remove(orderHeader);
            await db.SaveChangesAsync();

            return Ok(orderHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderHeaderExists(int id)
        {
            return db.OrderHeaders.Count(e => e.SalesOrderHeaderId == id) > 0;
        }
    }
}