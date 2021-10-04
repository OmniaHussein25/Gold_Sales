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
    public class vendorsController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: vendors
        public ActionResult Index()
        {
            return View(db.vendors.ToList());
        }

        // GET: vendors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vendor vendor = db.vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vendorid,VendorName,VendorDesc,rowcreateddate,MachineIP,MachineName,MachineUser,userid,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: vendors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vendor vendor = db.vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vendorid,VendorName,VendorDesc,rowcreateddate,MachineIP,MachineName,MachineUser,userid,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] vendor vendor)
        {
            if (ModelState.IsValid)
            {
                //vendor.r = DateTime.Now;
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: vendors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vendor vendor = db.vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: vendors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    vendor vendor = db.vendors.Find(id);
        //    db.vendors.Remove(vendor);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public JsonResult DeleteObj(string id)
        {
            bool res = false;
            vendor vendor = db.vendors.Find(id);
            if (vendor != null)
            {
                db.vendors.Remove(vendor);
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
