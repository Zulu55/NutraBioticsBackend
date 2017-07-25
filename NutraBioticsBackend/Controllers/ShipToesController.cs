using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NutraBioticsBackend.Models;

namespace NutraBioticsBackend.Controllers
{
    public class ShipToesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ShipToes
        public async Task<ActionResult> Index()
        {
            var shipToes = db.ShipToes.Include(s => s.Customer);
            return View(await shipToes.ToListAsync());
        }

        // GET: ShipToes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipTo shipTo = await db.ShipToes.FindAsync(id);
            if (shipTo == null)
            {
                return HttpNotFound();
            }
            return View(shipTo);
        }

        // GET: ShipToes/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Names");
            return View();
        }

        // POST: ShipToes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShipTo shipTo)
        {
            if (ModelState.IsValid)
            {
                db.ShipToes.Add(shipTo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Names", shipTo.CustomerId);
            return View(shipTo);
        }

        // GET: ShipToes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipTo shipTo = await db.ShipToes.FindAsync(id);
            if (shipTo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Names", shipTo.CustomerId);
            return View(shipTo);
        }

        // POST: ShipToes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShipTo shipTo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipTo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Names", shipTo.CustomerId);
            return View(shipTo);
        }

        // GET: ShipToes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipTo shipTo = await db.ShipToes.FindAsync(id);
            if (shipTo == null)
            {
                return HttpNotFound();
            }
            return View(shipTo);
        }

        // POST: ShipToes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ShipTo shipTo = await db.ShipToes.FindAsync(id);
            db.ShipToes.Remove(shipTo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
