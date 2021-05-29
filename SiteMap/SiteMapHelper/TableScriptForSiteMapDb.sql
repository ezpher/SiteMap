--drop existing table and stored procedure

IF OBJECT_ID('[dbo].[SiteMap]', 'U') IS NOT NULL BEGIN DROP TABLE [dbo].[SiteMap] END

IF OBJECT_ID('proc_GetSiteMap', 'P') IS NOT NULL BEGIN DROP PROC proc_GetSiteMap END

GO
-- Create the site map node table

CREATE TABLE [dbo].[SiteMap] (
    [ID]          [varchar] (50) NOT NULL,
    [Title]       [varchar] (32),
    [Description] [varchar] (512),
    [Url]         [varchar] (512),
    [Parent]      [varchar] (50)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SiteMap] ADD 
    CONSTRAINT [PK_SiteMap] PRIMARY KEY CLUSTERED 
    (
        [ID]
    )  ON [PRIMARY] 
GO

-- Add site map nodes

INSERT INTO SiteMap (ID, Title, Description, Url,  Parent)
VALUES ('01', 'Home', NULL, '~', NULL)

INSERT INTO SiteMap (ID, Title, Description, Url,  Parent)
VALUES ('01.01', 'News', NULL, '~/News', '01')

INSERT INTO SiteMap (ID, Title, Description, Url,  Parent)
VALUES ('01.01.01', 'Local', 'News from greater Seattle', '~/News/Local', '01.01')

INSERT INTO SiteMap (ID, Title, Description, Url,  Parent)
VALUES ('01.01.02', 'World', 'News from around the world', '~/News/World', '01.01')

INSERT INTO SiteMap (ID, Title, Description, Url,  Parent)
VALUES ('01.02', 'Sports', NULL, '~/Sports', '01')

INSERT INTO SiteMap (ID, Title, Description, Url,  Parent)
VALUES ('01.02.01', 'Baseball', 'What''s happening in baseball', '~/Sports/Baseball', '01.02')

GO

-- Create the stored proc used to query site map nodes

CREATE PROCEDURE proc_GetSiteMap AS
    SELECT [ID], [Title], [Description], [Url], [Parent]
    FROM [SiteMap] ORDER BY [ID]
GO