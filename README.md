# SiteMap
Demo of a sitemap stored in database

## Steps to Test in Local
1. Clone this repository to your local directory
2. Create a database `SiteMapDb` in SQL Server and run the db setup script under `SiteMap.SiteMap.TableScriptForSiteMapDb.sql` 
3. In Visual Studio, you can either set the startup project to `SiteMap` or `TestSiteMap`
4. `TestSiteMap` is a console program meant to test the retrieval of sitemap from db and the construction of the sitemap 
5. `SiteMap` is a ASP.NET MVC project meant to demonstrate the use of the sitemap for certain use cases 
    * e.g. Side navigation menu links that reflect the tree structure of the sitemap 
    * e.g. Breadcrumbs for each web page reflecting the path to the web page in the sitemap
