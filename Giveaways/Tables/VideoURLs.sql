CREATE TABLE [dbo].[VideoURLs](
	[VideoID] [int] NOT NULL,
	[URL] [nvarchar](50) NOT NULL,
	[CompanyID] [int] NOT NULL,
 CONSTRAINT [PK_VideoURLs] PRIMARY KEY CLUSTERED ([VideoID] ASC))