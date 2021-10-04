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
    public class CompanyEmpsController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: CompanyEmps
        public ActionResult Index()
        {
            var companyEmps = db.CompanyEmps.Include(c => c.Company);
            return View(companyEmps.ToList());
        }

        // GET: CompanyEmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmp companyEmp = db.CompanyEmps.Find(id);
            if (companyEmp == null)
            {
                return HttpNotFound();
            }
            return View(companyEmp);
        }

        // GET: CompanyEmps/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: CompanyEmps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,CompanyID,EmpName,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] CompanyEmp companyEmp)
        {
            if (ModelState.IsValid)
            {
                db.CompanyEmps.Add(companyEmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyEmp.CompanyID);
            return View(companyEmp);
        }

        // GET: CompanyEmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmp companyEmp = db.CompanyEmps.Find(id);
            if (companyEmp == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyEmp.CompanyID);
            return View(companyEmp);
        }

        // POST: CompanyEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,CompanyID,EmpName,active,rowcreateddate,MachineIP,MachineName,MachineUser,userid,rowupdateddate,Machineipupdated,Machinenameupdated,Machineuserupdated,useridupdated,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] CompanyEmp companyEmp)
        {
            if (ModelState.IsValid)
            {
                companyEmp.rowupdateddate = DateTime.Now;
                db.Entry(companyEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyEmp.CompanyID);
            return View(companyEmp);
        }

        // GET: CompanyEmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmp companyEmp = db.CompanyEmps.Find(id);
            if (companyEmp == null)
            {
                return HttpNotFound();
            }
            return View(companyEmp);
        }

        // POST: CompanyEmps/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CompanyEmp companyEmp = db.CompanyEmps.Find(id);
        //    db.CompanyEmps.Remove(companyEmp);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public JsonResult DeleteObj(string id)
        {
            bool res = false;
            CompanyEmp companyEmp = db.CompanyEmps.Find(id);
            if (companyEmp != null)
            {
                db.CompanyEmps.Remove(companyEmp);
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
