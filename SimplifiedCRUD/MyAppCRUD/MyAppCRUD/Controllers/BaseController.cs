using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAppCRUD.Repository;


namespace MyAppCRUD.Controllers
{
    public class BaseController : Controller
    {
        public SimplifiedCRUDEntities _db;
        public BaseRepository<Userr> _userRepo;

        public BaseController()
        {
            _db = new SimplifiedCRUDEntities();
            _userRepo = new BaseRepository<Userr>();
        }
    }
}