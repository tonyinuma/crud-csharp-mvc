using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cmvc.Models;
using cmvc.Models.TableViewModels;

namespace cmvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableVM> lst = null;
            using(cmvcEntities db = new cmvcEntities())
            {
                lst = (from d in db.user 
                      where d.idState == 1
                      orderby d.id
                      select new UserTableVM
                      {
                          Email = d.email,
                          Id = d.id,
                          Edad = d.edad
                      }).ToList();
            }
            return View(lst);
        }
    }
}