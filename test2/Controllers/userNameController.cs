using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test2.Models;

namespace test2.Controllers
{
    public class userNameController : Controller
    {
        user db = new user();

        public ActionResult Index()
        {
            var user = db.userNames.ToList();
            return View(user);
        }
        // GET: userName
        public ActionResult Next()
        {
            return View();
        }
        // POST: userName/Create
        [HttpPost]
        public ActionResult Next(userName use)
        {
            try
            {
                // TODO: Add insert logic here

                Session["userName"] = use;
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
        // GET: userName/Details/5
        public ActionResult Details(int id)
        {
            var userDetail = db.userNames.Find(id);
            return View(userDetail);
        }

        // GET: userName/Create
        public ActionResult Create()
        {
            var Gen = new SelectList(db.Genners, "ID", "NameGenner");
            ViewBag.IDGenner = Gen;
            if (Session["userName"] == null)
            {
                return View("index");
            }
            return View();
        }

        // POST: userName/Create
        [HttpPost]
        public ActionResult Create(userName model)
        {
            try
            {
                var u = Session["userName"] as userName;
                var user1 = new userName();
                user1.FirstName = u.FirstName;
                user1.LastName = u.LastName;
                user1.Email = u.Email;
                user1.Password = u.Password;
                user1.Phone = model.Phone;
                user1.OldMail = model.OldMail;
                user1.Date = model.Date;
                user1.IDGenner = model.IDGenner;
                db.userNames.Add(user1);
                var m = db.userNames.SingleOrDefault(x => x.Email== user1.Email);
                if (m == null) 
                    {
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                else
                {
                    ViewBag.Fail = "Email đã tồn tại";
                    return View("Create");
                }

            }
            catch
            {
                return View("Create");
            }
        }   
        // GET: userName/Edit/5
        public ActionResult Edit(int id)
        {
            var Editing = db.userNames.Find(id);
            var Gen = new SelectList(db.Genners, "ID", "NameGenner",Editing.IDGenner);
            ViewBag.IDGenner = Gen;
            return View(Editing);
        }

        // POST: userName/Edit/5
        [HttpPost]
        public ActionResult Edit(userName model)
        {
            try
            {
                var userEdit = db.userNames.Find(model.ID);
                userEdit.FirstName = model.FirstName;
                userEdit.LastName = model.LastName;
                userEdit.Email = model.Email;
                userEdit.Password = model.Password;
                userEdit.Phone = model.Phone;
                userEdit.OldMail = model.OldMail;
                userEdit.Date = model.Date;
                userEdit.IDGenner = model.IDGenner;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: userName/Delete/5
        public ActionResult Delete(int id)
        {
            var del = db.userNames.Find(id);
            return View(del);
        }

        // POST: userName/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var del = db.userNames.Find(id);
                db.userNames.Remove(del);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        // POST: userName/Create
        [HttpPost]
        public ActionResult Login(FormCollection userlog)
        {

            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.userNames.SingleOrDefault(x => x.Email.Equals(userMail) && x.Password.Equals(password));
            if(islogin != null)
            {
                Session["user"] = userMail;
                return RedirectToAction("info");
            }
            else
            {
                ViewBag.Fail = "Đăng nhập thất bại";
                return View("login");
            }
        }
        public ActionResult info()
        {
            return View();
        }
        // POST: userName/Create

    }


}
