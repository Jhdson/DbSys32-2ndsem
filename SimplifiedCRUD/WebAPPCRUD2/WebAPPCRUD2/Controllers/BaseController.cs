using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPPCRUD2.Repository;

namespace WebAPPCRUD2.Controllers
{
    public class BaseController : Controller
    {
        public SimplifiedCRUDDEntities _db;
        public BaseRepository<Userr> _userRepo;

        public BaseController()
        {
            _db = new SimplifiedCRUDDEntities();
            _userRepo = new BaseRepository<Userr>();
        }
    }
}