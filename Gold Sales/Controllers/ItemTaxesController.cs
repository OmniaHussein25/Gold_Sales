using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gold_Sales.Models;

namespace Gold_Sales.Controllers
{
    public class ItemTaxesController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: ItemTaxes
        public ActionResult Index()
        {
            var itemTaxes = db.ItemTaxes.Include(i => i.Item).Include(i => i.Tax);
            return View(itemTaxes.ToList());
        }

        // GET: ItemTaxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTax itemTax = db.ItemTaxes.Find(id);
            if (itemTax == null)
            {
                return HttpNotFound();
            }
            return View(itemTax);
        }

        // GET: ItemTaxes/Create
        public ActionResult Create()
        {
            ViewBag.itemID = new SelectList(db.Items, "ItemID", "CompanyID");
            ViewBag.taxID = new SelectList(db.Taxes, "TaxID", "TaxName");
            return View();
        }

        // POST: ItemTaxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemtaxID,itemID,taxID,itemtaxspecval,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated")] ItemTax itemTax)
        {
            if (ModelState.IsValid)
            {
                db.ItemTaxes.Add(itemTax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemID = new SelectList(db.Items, "ItemID", "CompanyID", itemTax.itemID);
            ViewBag.taxID = new SelectList(db.Taxes, "TaxID", "TaxName", itemTax.taxID);
            return View(itemTax);
        }

        // GET: ItemTaxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTax itemTax = db.ItemTaxes.Find(id);
            if (itemTax == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemID = new SelectList(db.Items, "ItemID", "CompanyID", itemTax.itemID);
            ViewBag.taxID = new SelectList(db.Taxes, "TaxID", "TaxName", itemTax.taxID);
            return View(itemTax);
        }

        // POST: ItemTaxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemtaxID,itemID,taxID,itemtaxspecval,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated")] ItemTax itemTax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemTax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemID = new SelectList(db.Items, "ItemID", "CompanyID", itemTax.itemID);
            ViewBag.taxID = new SelectList(db.Taxes, "TaxID", "TaxName", itemTax.taxID);
            return View(itemTax);
        }

        // GET: ItemTaxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTax itemTax = db.ItemTaxes.Find(id);
            if (itemTax == null)
            {
                return HttpNotFound();
            }
            return View(itemTax);
        }

        // POST: ItemTaxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemTax itemTax = db.ItemTaxes.Find(id);
            db.ItemTaxes.Remove(itemTax);
            db.SaveChanges();
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
