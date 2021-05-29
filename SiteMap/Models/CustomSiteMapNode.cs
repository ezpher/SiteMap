using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMap.Models
{
    public class CustomSiteMapNode
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Parent { get; set; }

        public ICollection<CustomSiteMapNode> Children { get; set; } = new List<CustomSiteMapNode>();
    }
}