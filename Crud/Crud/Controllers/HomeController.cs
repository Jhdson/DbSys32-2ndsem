using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<CreateTable>();
            using (var db = new CRUDEntities())
            {
                list = db.CreateTable.ToList();
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateTable u)
        {

            using (var db = new CRUDEntities())
            {
                var newUser = new CreateTable();
                newUser.username = u.username;
                newUser.password = u.password;

                db.CreateTable.Add(newUser);
                db.SaveChanges();


                TempData["msg"] = $"ADDED {newUser.username} SUCCESSFULLY!"; 
            }
                return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var user = new CreateTable();
            using (var db = new CRUDEntities())
            {
                user = db.CreateTable.Find(id);

            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(CreateTable u)
        {

            using (var db = new CRUDEntities())
            {
                var newUser = db.CreateTable.Find(u.id);
                newUser.username = u.username;
                newUser.password = u.password;

          
                db.SaveChanges();


                TempData["msg"] = $"UPDATED {newUser.username} SUCCESSFULLY!";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
      
            using (var db = new CRUDEntities())
            {
                var user = new CreateTable();
                user = db.CreateTable.Find(id);
                db.CreateTable.Remove(user);

                db.SaveChanges();

                TempData["msg"] = $"DELETED {user.username} SUCCESSFULLY!";
            }
            return RedirectToAction("Index");
        }
       
      
    }
}