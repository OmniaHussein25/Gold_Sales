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
    public class CurrencyRatesController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: CurrencyRates
        public ActionResult Index()
        {
            var currencyRates = db.CurrencyRates.Include(c => c.Currency);
            return View(currencyRates.ToList());
        }

        // GET: CurrencyRates/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            return View(currencyRate);
        }

        // GET: CurrencyRates/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Currencyname");
            return View();
        }

        // POST: CurrencyRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrencyID,CurrRateDate,CurrRate,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated")] CurrencyRate currencyRate)
        {
            if (ModelState.IsValid)
            {
                db.CurrencyRates.Add(currencyRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Currencyname", currencyRate.CurrencyID);
            return View(currencyRate);
        }

        // GET: CurrencyRates/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Currencyname", currencyRate.CurrencyID);
            return View(currencyRate);
        }

        // POST: CurrencyRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrencyID,CurrRateDate,CurrRate,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated")] CurrencyRate currencyRate)
        {
            if (ModelState.IsValid)
            {
                currencyRate.rowupdateddate = DateTime.Now;
                db.Entry(currencyRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Currencyname", currencyRate.CurrencyID);
            return View(currencyRate);
        }

        // GET: CurrencyRates/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            return View(currencyRate);
        }

        // POST: CurrencyRates/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    CurrencyRate currencyRate = db.CurrencyRates.Find(id);
        //    db.CurrencyRates.Remove(currencyRate);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public JsonResult DeleteObj(string id)
        {
            bool res = false;
            CurrencyRate currencyrate = db.CurrencyRates.Find(id);
            if (currencyrate != null)
            {
                db.CurrencyRates.Remove(currencyrate);
                db.SaveChanges();
                res = true;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
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
