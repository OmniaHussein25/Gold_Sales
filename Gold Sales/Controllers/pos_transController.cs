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
    public class pos_transController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: pos_trans
        public ActionResult Index()
        {
            return View(db.pos_trans.ToList());
        }

        // GET: pos_trans/Details/5
        public ActionResult Details(int? trans_id, string store_code)
        {
            if (trans_id == null  || store_code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pos_trans pos_trans = db.pos_trans.Where(a => a.trans_id == trans_id &&  a.store_code == store_code).FirstOrDefault();
            if (pos_trans == null)
            {
                return HttpNotFound();
            }
            return View(pos_trans);
        }

        // GET: pos_trans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pos_trans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trans_id,store_code,trans_date,client_code,trans_total,remarks,trans_total_21,trans_toatl_18,canceled,syncstatus,inventsiteid,axsync,returnorder,closure_date,rowcreateddate,total_weight,total_line,MachineIP,MachineUser,Machinename,userid,MachineIPupdated,MachineUserupdated,MachineNameupdated,useridupdated,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] pos_trans pos_trans)
        {
            if (ModelState.IsValid)
            {
                db.pos_trans.Add(pos_trans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pos_trans);
        }

        // GET: pos_trans/Edit/5
        public ActionResult Edit(int? trans_id, string store_code)
        {
            if (trans_id == null || store_code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pos_trans pos_trans = db.pos_trans.Where(a => a.trans_id == trans_id && a.store_code == store_code).FirstOrDefault();
            if (pos_trans == null)
            {
                return HttpNotFound();
            }
            return View(pos_trans);
        }

        // POST: pos_trans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trans_id,store_code,trans_date,client_code,trans_total,remarks,trans_total_21,trans_toatl_18,canceled,syncstatus,inventsiteid,axsync,returnorder,closure_date,rowcreateddate,total_weight,total_line,MachineIP,MachineUser,Machinename,userid,MachineIPupdated,MachineUserupdated,MachineNameupdated,useridupdated,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] pos_trans pos_trans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pos_trans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pos_trans);
        }

        // GET: pos_trans/Delete/5
        ////public ActionResult Delete(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    pos_trans pos_trans = db.pos_trans.Find(id);
        ////    if (pos_trans == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(pos_trans);
        ////}
        public JsonResult DeleteObj(int? trans_id, string store_code)
        {
            bool res = false;
            pos_trans pos_trans = db.pos_trans.Where(a => a.trans_id == trans_id && a.store_code == store_code).FirstOrDefault();
            if (pos_trans != null)
            {
                db.pos_trans.Remove(pos_trans);
                db.SaveChanges();
                res = true;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // POST: pos_trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pos_trans pos_trans = db.pos_trans.Find(id);
            db.pos_trans.Remove(pos_trans);
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
