using SiteMap.Models;
using SiteMap.SiteMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSiteMap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Test Getting SiteMap From Db
                IEnumerable<CustomSiteMapNode> siteMap = SiteMapHelper.GetSiteMap();

                foreach (var row in siteMap)
                {
                    Console.WriteLine(
                        string.Format("{0} | {1} | {2} | {3} | {4}",
                            row.ID,
                            row.Title,
                            string.IsNullOrEmpty(row.Description) ? "null" : row.Description,
                            row.Url,
                            string.IsNullOrEmpty(row.Parent) ? "null" : row.Parent)
                        );
                }
                #endregion
                
                Console.WriteLine();
                Console.WriteLine();

                #region Test Constructing Html SiteMap
                string siteMapHtml = SiteMapHelper.ConstructSiteMapHtml(SiteMapHelper.ConstructSiteMap());
                Console.WriteLine(siteMapHtml);
                #endregion

                Console.ReadKey();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
