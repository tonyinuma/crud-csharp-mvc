using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cmvc.Models;


namespace cmvc.Controllers
{
    public class AccessController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                //return Content("1");
                using (cmvcEntities db = new cmvcEntities())
                {
                    var ls = from d in db.user
                             where d.email == user && d.password == password && d.idState == 1
                             select d;
                    if (ls.Count()>0)
                    {
                        user oUser = ls.First();
                        Session["User"] = oUser;

                        return Content("1");
                        //Session["User"] = ls.First();
                    }
                    else
                    {
                        return Content("Usuario o contraseña incorrecto");
                    }
                }
            }
            catch(Exception ex)
            {
                return Content("Ocurrio un error :( "+ex.Message);
            }
            //return View();
        }
    }
}