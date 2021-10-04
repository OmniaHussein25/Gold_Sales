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
    public class pos_trans_gridController : Controller
    {
        private Gold_SalesEntities db = new Gold_SalesEntities();

        // GET: pos_trans_grid
        public ActionResult Index()
        {
            var pos_trans_grid = db.pos_trans_grid.Include(p => p.pos_trans);
            return View(pos_trans_grid.ToList());
        }

        // GET: pos_trans_grid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pos_trans_grid pos_trans_grid = db.pos_trans_grid.Find(id);
            if (pos_trans_grid == null)
            {
                return HttpNotFound();
            }
            return View(pos_trans_grid);
        }

        // GET: pos_trans_grid/Create
        public ActionResult Create()
        {
            ViewBag.trans_id = new SelectList(db.pos_trans, "trans_id", "client_code");
            return View();
        }

        // POST: pos_trans_grid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trans_id,linenum,store_code,itemname,unit_code,item_weight,sale_price,slae_cost,trans_date,item_sold,syncstatus,inventdimid,parmitemid,stockid,itemserial,rowcreateddate,tax,taxrate,taxrates,taxes,MachineIP,MachineUser,MachineName,userid,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] pos_trans_grid pos_trans_grid)
        {
            if (ModelState.IsValid)
            {
                db.pos_trans_grid.Add(pos_trans_grid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.trans_id = new SelectList(db.pos_trans, "trans_id", "client_code", pos_trans_grid.trans_id);
            return View(pos_trans_grid);
        }

        // GET: pos_trans_grid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pos_trans_grid pos_trans_grid = db.pos_trans_grid.Find(id);
            if (pos_trans_grid == null)
            {
                return HttpNotFound();
            }
            ViewBag.trans_id = new SelectList(db.pos_trans, "trans_id", "client_code", pos_trans_grid.trans_id);
            return View(pos_trans_grid);
        }

        // POST: pos_trans_grid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trans_id,linenum,store_code,itemname,unit_code,item_weight,sale_price,slae_cost,trans_date,item_sold,syncstatus,inventdimid,parmitemid,stockid,itemserial,rowcreateddate,tax,taxrate,taxrates,taxes,MachineIP,MachineUser,MachineName,userid,iabc,idef,ighi,ijkl,Sabc,Sdef,Sghi,Sjkl,Dabc,Ddef,Dghi,Djkl,DECabc,DECdef,DECghi,DECjkl")] pos_trans_grid pos_trans_grid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pos_trans_grid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trans_id = new SelectList(db.pos_trans, "trans_id", "client_code", pos_trans_grid.trans_id);
            return View(pos_trans_grid);
        }

        // GET: pos_trans_grid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pos_trans_grid pos_trans_grid = db.pos_trans_grid.Find(id);
            if (pos_trans_grid == null)
            {
                return HttpNotFound();
            }
            return View(pos_trans_grid);
        }

        // POST: pos_trans_grid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pos_trans_grid pos_trans_grid = db.pos_trans_grid.Find(id);
            db.pos_trans_grid.Remove(pos_trans_grid);
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
