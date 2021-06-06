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

        // GET: News/World/Asia/EastAsia
        [Route("News/World/Asia/EastAsia")]
        public ActionResult EastAsia()
        {
            return View();
        }

        // GET: News/World/Asia/SoutheastAsia
        [Route("News/World/Asia/SoutheastAsia")]
        public ActionResult SoutheastAsia()
        {
            return View();
        }

        // GET: News/World/LatinAmerica
        [Route("News/World/LatinAmerica")]
        public ActionResult LatinAmerica()
        {
            return View();
        }
    }
}
