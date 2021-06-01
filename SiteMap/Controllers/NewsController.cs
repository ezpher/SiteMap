using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMap.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        // GET: News/Local
        public ActionResult Local()
        {
            return View();
        }

        // GET: News/World
        public ActionResult World()
        {
            return View();
        }
    }
}
