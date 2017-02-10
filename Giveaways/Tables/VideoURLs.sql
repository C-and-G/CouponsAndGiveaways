CREATE TABLE [dbo].[VideoURLs](
	[VideoId] [int] NOT NULL,
	[URL] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_VideoURLs] PRIMARY KEY CLUSTERED ([VideoId] ASC),
 CONSTRAINT [FK_VideoURLs_Company] FOREIGN KEY([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
 )