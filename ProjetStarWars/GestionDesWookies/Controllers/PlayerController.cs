using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesWookies.Controllers
{
    public class PlayerController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            this.Session["USER_LOGIN"] = login;
            this.Session["PASSWORD"] = password;

            return RedirectToAction("CreateAttaque", "Game");
        }

        
    }
}
