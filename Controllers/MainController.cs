using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
   [Authorize]
    public class MainController : Controller
    {
        // GET: Main
        [Authorize(Roles = "Admin,supervisor")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

    }
}