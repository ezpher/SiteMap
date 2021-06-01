using SiteMap.Models;
using SiteMap.SiteMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SiteMap.Breadcrumb
{
    public static class BreadcrumbHelper
    {
        public static MvcHtmlString ConstructBreadcrumb(this HtmlHelper htmlHelper)
        {

            IEnumerable<CustomSiteMapNode> siteMap = SiteMapHelper.GetSiteMap();
            if (siteMap == null || siteMap.Count() == 0) return new MvcHtmlString(null);

            HttpRequest request = HttpContext.Current.Request;
            string url = RemoveQueryStringParams(request.AppRelativeCurrentExecutionFilePath);

            CustomSiteMapNode targetNode = siteMap.Where(node => node.Url != null && node.Url.ToLower().Trim() == url.ToLower().Trim()).FirstOrDefault();
            CustomSiteMapNode parentNode = siteMap.Where(node => targetNode != null && node.ID == targetNode.Parent).FirstOrDefault();
            if (targetNode == null || parentNode == null) return new MvcHtmlString(null);

            Stack<CustomSiteMapNode> nodeStack = new Stack<CustomSiteMapNode>();
            nodeStack.Push(targetNode);
            while (parentNode != null)
            {
                nodeStack.Push(parentNode);
                parentNode = siteMap.Where(node => node.ID == parentNode.Parent).FirstOrDefault();
            }

            return ConstructBreadcrumbHtml(nodeStack);
        }

        public static MvcHtmlString ConstructBreadcrumbHtml(Stack<CustomSiteMapNode> nodeStack)
        {
            if (nodeStack != null && nodeStack.Count > 0)
            {
                TagBuilder breadcrumbContainer = new TagBuilder("div");

                string delimiter = " >> ";
                foreach (var node in nodeStack)
                {
                    TagBuilder nodeTag = new TagBuilder("span");                 
                    string nodeInnerText = node.Title + delimiter;
                    nodeTag.SetInnerText(nodeInnerText);

                    breadcrumbContainer.InnerHtml += nodeTag;
                }

                breadcrumbContainer.InnerHtml = breadcrumbContainer.InnerHtml.RemoveLastBreadcrumbDelimiter();
                return new MvcHtmlString(breadcrumbContainer.ToString());
            }

            return new MvcHtmlString(null);
        }

        public static string RemoveQueryStringParams(this string url)
        {
            string pattern = "[\\?]=";
            url = Regex.Replace(url, pattern, string.Empty);

            return url.Trim();
        }

        public static string RemoveLastBreadcrumbDelimiter(this string breadcrumb)
        {
            string find = " &gt;&gt; ";
            string replace = string.Empty;
            int lastIndex = breadcrumb.LastIndexOf(find);

            if (lastIndex == -1)
            {
                return breadcrumb;
            }

            string beginString = breadcrumb.Substring(0, lastIndex);
            string endString = breadcrumb.Substring(lastIndex + find.Length);
            breadcrumb = beginString + replace + endString;

            return breadcrumb;
        }
    }
}