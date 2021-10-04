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
    public class ItemUnitsController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: ItemUnits
        public ActionResult Index()
        {
            return View(db.ItemUnits.ToList());
        }

        // GET: ItemUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnit itemUnit = db.ItemUnits.Find(id);
            if (itemUnit == null)
            {
                return HttpNotFound();
            }
            return View(itemUnit);
        }

        // GET: ItemUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemunitcode,itemunitname,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated")] ItemUnit itemUnit)
        {
            if (ModelState.IsValid)
            {
                db.ItemUnits.Add(itemUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemUnit);
        }

        // GET: ItemUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnit itemUnit = db.ItemUnits.Find(id);
            if (itemUnit == null)
            {
                return HttpNotFound();
            }
            return View(itemUnit);
        }

        // POST: ItemUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemunitcode,itemunitname,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated")] ItemUnit itemUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemUnit);
        }

        // GET: ItemUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnit itemUnit = db.ItemUnits.Find(id);
            if (itemUnit == null)
            {
                return HttpNotFound();
            }
            return View(itemUnit);
        }

        // POST: ItemUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemUnit itemUnit = db.ItemUnits.Find(id);
            db.ItemUnits.Remove(itemUnit);
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
