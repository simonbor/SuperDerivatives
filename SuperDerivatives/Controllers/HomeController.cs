using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperDerivatives.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Matlab()
        {
            ViewBag.Message = "Your Matlab page.";

            return View();
        }
    }
}