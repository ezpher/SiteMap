using SiteMap.Models;
using SiteMap.SiteMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult Navigation()
        {
            CustomSiteMapNode rootMenu = SiteMapHelper.ConstructSiteMap();
            ConstructUrl(rootMenu);
                       
            return PartialView("_Navigation", rootMenu);
        }

        public void ConstructUrl(CustomSiteMapNode menuNode)
        {
            if (menuNode == null) return;

            if (!string.IsNullOrEmpty(menuNode.Url) && menuNode.Url.StartsWith("~/"))
                menuNode.Url = Url.Content(menuNode.Url);

            if (string.IsNullOrEmpty(menuNode.Url))
                menuNode.Url = "#";

            if (menuNode.Children != null && menuNode.Children.Count > 0)
            {
                foreach (CustomSiteMapNode childMenu in menuNode.Children)
                {
                    ConstructUrl(childMenu);
                }
            }
        }
    }
}