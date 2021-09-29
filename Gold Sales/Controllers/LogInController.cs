
using Gold_Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gold_Sales.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user objUser)
        {

            //Session["UserName"] = "Twitty";
            //Session["UserID"] = "123456";
            //return RedirectToAction("HomePage");

            if (ModelState.IsValid)
            {
                using (Gold_SalesEntities db = new Gold_SalesEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objUser.username) && a.userpassword.Equals(objUser.userpassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.userid.ToString();
                        Session["UserName"] = obj.username.ToString();
                        ViewBag.UserName = obj.username.ToString();
                        return RedirectToAction("HomePage");
                        //return RedirectToRoute("Home/Index");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult HomePage()
        {
            if (Session["UserID"] != null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
