﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cmvc.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Index","Access");
        }

    }
}