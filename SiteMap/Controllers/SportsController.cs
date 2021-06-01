using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMap.Controllers
{
    public class SportsController : Controller
    {
        // GET: Sports
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sports/Baseball
        public ActionResult Baseball()
        {
            return View();
        }
    }
}
