using SiteMap.DAL;
using SiteMap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SiteMap.SiteMap
{
    public static class SiteMapHelper
    {
        // Primary use is for testing site map construction is correct
        public static string ConstructSiteMapHtml(CustomSiteMapNode parentNode)
        {
            StringBuilder htmlOutput = new StringBuilder();

            if (parentNode.Children != null && parentNode.Children.Count() > 0)
            {
                htmlOutput.Append("<ul>");

                if (string.IsNullOrEmpty(parentNode.Parent))
                {
                    var rootNode = parentNode;
                    htmlOutput.Append(rootNode.Title);
                }

                foreach (CustomSiteMapNode childNode in parentNode.Children)
                {
                    htmlOutput.Append("<li>");
                    htmlOutput.Append(childNode.Title);
                    htmlOutput.Append(ConstructSiteMapHtml(childNode));
                    htmlOutput.Append("</li>");
                }

                htmlOutput.Append("</ul>");
            }

            return htmlOutput.ToString(); 
        }

        public static CustomSiteMapNode ConstructSiteMap()
        {
            IEnumerable<CustomSiteMapNode> siteMap = GetSiteMap();
            CustomSiteMapNode rootNode = siteMap.Where(node => string.IsNullOrEmpty(node.Parent)).FirstOrDefault();

            if (rootNode == null) throw new Exception("Root Node is Empty!");
            AddChildNode(rootNode, siteMap);

            return rootNode;
        }

        public static IEnumerable<CustomSiteMapNode> GetSiteMap()
        {
            DbHelper dbHelper = new DbHelper();
            DataTable dt = dbHelper.ExecuteQueryToDataTableByStoredProc("proc_GetSiteMap", new Dictionary<string, System.Data.SqlClient.SqlParameter>());

            IEnumerable<CustomSiteMapNode> siteMap = dt.DataTableToList<CustomSiteMapNode>();

            return siteMap;
        }

        public static void AddChildNode(CustomSiteMapNode parentNode, IEnumerable<CustomSiteMapNode> siteMap)
        {
            IEnumerable<CustomSiteMapNode> childrenNodes = siteMap.Where(node => node.Parent == parentNode.ID);

            foreach (var childNode in childrenNodes)
            {
                AddChildNode(childNode, siteMap);

                parentNode.Children.Add(childNode);
            }
        }
 
    }
}