using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAppCRUD.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Userr> userList = _userRepo.GetAll();
            return View(userList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Userr u )
        {
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.username} added! ";
            return RedirectToAction("Index");
        }

        public  ActionResult Details(int id)
        {
            return View(_userRepo.get(id));
        }
        public ActionResult Edit(int id)
        {
            return View(_userRepo.get(id));
        }
        [HttpPost]
        public ActionResult Edit(Userr u)
        {
            _userRepo.Update(u.id,u);
            TempData["Msg"] = $"User {u.username} updated! ";
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            TempData["Msg"] = $"User Deleted! ";
            return RedirectToAction("Index");
        }
    }
}